using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the starting position to the objects current position
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the period is less than or equal to the smallest possible float return
        if (period <= Mathf.Epsilon) { return; }

        float fltCycles = Time.time / period; // Continually growing over time
        
        const float FLTTAU = Mathf.PI * 2; // Constant value of 6.28
        float fltRawSinWave = Mathf.Sin(fltCycles * FLTTAU); // Going from -1 to 1

        movementFactor = (fltRawSinWave + 1f) / 2f; // Recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
