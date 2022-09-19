using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 0f;
    void OnCollisionEnter(Collision other)
    {
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
        // Todo add sound effect
        // Todo add particles
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", fltLevelLoadDelay);
    }

    void StartCrashSequence()
    {
        // Todo add sound effect on crash
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
