using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float minX, maxX, minY, maxY;

    void Update()
    {
        // Get the target's position
        Vector3 targetPos = target.position;

        // Clamp the camera position to the game world boundaries
        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

        // Set the camera position to the clamped position, keeping the original z value
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
