using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fltMainThrust = 0f;
    [SerializeField] float fltRotatationThrust = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get rocket's rigidbody
        rb = GetComponent<Rigidbody>();
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
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Apply positive rotation
            ApplyRotation(fltRotatationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Apply negative rotation
            ApplyRotation(-fltRotatationThrust);
        }
    }

    void ApplyRotation(float fltRotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * fltRotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // UnFreezing rotation so the physics system can take over
    }
}
