using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    Animator animator;

    AudioGame audioGame;

    void Start()
    {

        animator = GetComponent<Animator>();
        audioGame = FindObjectOfType<AudioGame>();

    }

    void Update()
    {
        // Move Enemy
        //FollowPath();
        if (GetComponent<FOV2>().isDetected == true || GetComponent<SelfDetection>().isDetected == true)
        {
            animator.SetBool("isDetected", true);
            // Facing the player when detected
            // Calculate direction vector from enemy to player
            Vector3 direction = FindObjectOfType<PlayerMovement>().transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Play Audio
            audioGame.PlayDetectedClip();
        }

    }

    
}
