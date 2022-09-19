using UnityEngine;

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
                Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHhh");
            break;
        }
    }
}
