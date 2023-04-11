using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV2 : MonoBehaviour
{
    public float fovAngle = 40f;
    public Transform fovPoint;
    public float range = 6f;
    public Transform target;
    public float rotationSpeed = 15f;

    public bool isDetected = false;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        Detection();
    }

    public void Detection()
    {
        // Cast a ray to check if the target is within the FOV and range
        Vector2 direction = target.position - transform.position;
        float angle = Vector3.Angle(direction, fovPoint.right);
        RaycastHit2D r = Physics2D.Raycast(fovPoint.position, direction, range);

        if (angle < fovAngle / 2f)
        {
            if (r.collider != null && r.collider.CompareTag("Player"))
            {
                rotationSpeed = 0f;
                isDetected = true;
                FindObjectOfType<PlayerMovement>().StopMove();
                print("SEEN!");
                FindObjectOfType<GameManager>().EndGame();
            }
        }
        else
        {
            isDetected = false;
        }
    }

    public bool detectedAnim()
    {
        return isDetected;
    }
}
