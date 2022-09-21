using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 0f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool boolIsTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(boolIsTransitioning) {return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Collided with Friendly thing");
            break;
            case "Finish":
                StartSuccessSequence();
            break;
            case "Fuel":
                Debug.Log("Collided with the FUeld Objec");
            break;
            default:
                StartCrashSequence();
            break;
        }
    }

    void StartSuccessSequence()
    {
        boolIsTransitioning = true;

        // Stop all audio and play success sound
        audioSource.Stop();
        audioSource.PlayOneShot(success);

        // Play particles
        successParticles.Play();

        // Todo add particles
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", fltLevelLoadDelay);
    }

    void StartCrashSequence()
    {
        boolIsTransitioning = true;

        // Stop all audio and play crash sound
        audioSource.Stop();
        audioSource.PlayOneShot(crash);

        // Play particles
        crashParticles.Play();

        // Todo add particles on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", fltLevelLoadDelay);
    }

    void LoadNextLevel()
    {
        // Get the current scene/level index
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int intNextSceneIndex = intCurrentSceneIndex + 1;

        // If the next scene is equal to the number of scenes in the build settings
        if (intNextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            // Reset next scene index
            intNextSceneIndex = 0;
        }

        // Go to next scene index
        SceneManager.LoadScene(intNextSceneIndex);
    }

    void ReloadLevel()
    {
        // Get the current scene/level index
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Reload the current scene/level
        SceneManager.LoadScene(intCurrentSceneIndex);
    }
}
