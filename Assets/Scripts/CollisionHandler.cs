using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Collided with Friendly thing");
            break;
            case "Finish":
                LoadNextLevel();
            break;
            case "Fuel":
                Debug.Log("Collided with the FUeld Objec");
            break;
            default:
                ReloadLevel();
            break;
        }
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
