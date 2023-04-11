using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Detection : MonoBehaviour
{
    public float fovAngle = 90f;
    public Transform fovPoint;
    public float range = 4f;
    public Transform target;

    public bool isDetected = false;

    void Update()
    {
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
