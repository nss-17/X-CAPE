using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDetection : MonoBehaviour
{
    Vector2 distance;
    public Transform target;
    public float detectRadius = 1.1f;

    public bool isDetected = false;
    void Update()
    {
        // Detection if player nearby
        distance = target.position - transform.position;
        
        // Detect nearby
        float distanceMagnitude = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        
        if (distanceMagnitude <= detectRadius)
        {
            isDetected = true;
            FindObjectOfType<PlayerMovement>().StopMove();
            print("DETECTED!");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
