using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorTrigger0 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI needKeyText;

    Key0 key;

    public GameObject door0;

    void Awake()
    {
        key = FindObjectOfType<Key0>();
    }

    void Start()
    {
        needKeyText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (!key.hasKey0)
            {
                needKeyText.gameObject.SetActive(true);
            }
            else
            {
                Destroy(door0);
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
