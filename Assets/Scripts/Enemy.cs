using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    private int waypointIndex = 0;

    
    public float delay = 1f;
    private float timer = 0f;

    Animator animator;

    private Vector3 previousPosition;

    AudioGame audioGame;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        transform.position = waypoints[waypointIndex].position;
        audioGame = FindObjectOfType<AudioGame>();

    }

    void Update()
    {
        // Move Enemy
        //FollowPath();
        if (GetComponent<FOV_Detection>().isDetected == true || GetComponent<SelfDetection>().isDetected == true)
        {
            animator.SetBool("isDetected", true);
            moveSpeed = 0f;
            // Facing the player when detected
            // Calculate direction vector from enemy to player
            Vector3 direction = FindObjectOfType<PlayerMovement>().transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Play Audio
            audioGame.PlayDetectedClip();
        }
        else
        {
            FollowPath();
        }

    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPos = waypoints[waypointIndex].position;
            // Move Enemy from current waypoint to the next one
            transform.position = Vector2.MoveTowards(transform.position, targetPos,
               moveSpeed * Time.deltaTime);

            // Check the enemy's movement direction and rotate the FOV point accordingly
            Vector3 movementDirection = transform.position - previousPosition;
            previousPosition = transform.position;
            if (movementDirection.x < 0)
            {
                //left
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (movementDirection.x > 0)
            {
                // right
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (movementDirection.y > 0)
            {
                // up
                transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if (movementDirection.y < 0)
            {
                // down
                transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }

            if (transform.position == targetPos)
            {
                if(timer < delay)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    waypointIndex += 1;

                    // If the enemy has reached the end of the path,
                    // turn around and move backwards
                    if (waypointIndex == waypoints.Count)
                    {
                        // Reverse the order of the waypoints
                        waypoints.Reverse();
                        // Start moving towards the new first waypoint
                        waypointIndex = 0;
                    }
                    timer = 0f;
                }
                
            }
        }
    }

}
