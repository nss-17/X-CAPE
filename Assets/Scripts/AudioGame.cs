using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioGame : MonoBehaviour
{
    [Header("Detected")]
    [SerializeField] AudioClip detectedClip;
    [SerializeField] [Range(0f, 1f)] float detectedVolume = 1f;

    void Awake()
    {
        ManagerSingleton();
    }

    void ManagerSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayDetectedClip()
    {
        if(detectedClip != null)
        {
            AudioSource.PlayClipAtPoint(detectedClip, Camera.main.transform.position, detectedVolume);

        }
    }
}
