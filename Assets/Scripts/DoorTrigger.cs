using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI needKeyText;

    Key key;

    public GameObject door;

    void Awake()
    {
        key = FindObjectOfType<Key>();
    }

    void Start()
    {
        needKeyText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (!key.hasKey)
            {
                needKeyText.gameObject.SetActive(true);
            }
            else
            {
                Destroy(door);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            needKeyText.gameObject.SetActive(false);
            
        }
    }
}
