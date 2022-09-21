using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float fltMainThrust = 0f;
    [SerializeField] float fltRotatationThrust = 0f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    // Start is called before the first frame update
    void Start()
    {
        // Get rocket's rigidbody
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Add upwards thrust relative to rockets coordinates
            rb.AddRelativeForce(Vector3.up * fltMainThrust * Time.deltaTime);
            // If the audio is not play
            if (!audioSource.isPlaying)
            {
                // Play the audio
                audioSource.PlayOneShot(mainEngine);
            }
            if(!mainThrusterParticles.isPlaying)
            {
                mainThrusterParticles.Play();
            }
        }
        else
        {
            // Stop the audio from playing
            audioSource.Stop();
            mainThrusterParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Apply positive rotation
            ApplyRotation(fltRotatationThrust);

            if(!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Apply negative rotation
            ApplyRotation(-fltRotatationThrust);
            
            if(!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();
        }
    }

    void ApplyRotation(float fltRotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * fltRotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // UnFreezing rotation so the physics system can take over
    }
}
