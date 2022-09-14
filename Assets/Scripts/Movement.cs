using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fltMainThrust = 0f;

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
            Debug.Log("Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating Right");
        }
    }
}
