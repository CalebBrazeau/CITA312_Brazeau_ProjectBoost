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
                Debug.Log("Collided with the fnish thingy");
            break;
            case "Fuel":
                Debug.Log("Collided with the FUeld Objec");
            break;
            default:
                ReloadLevel();
            break;
        }
    }

    void ReloadLevel()
    {
        // Get the current scene/level index
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Reload the current scene/level
        SceneManager.LoadScene(intCurrentSceneIndex);
    }
}
