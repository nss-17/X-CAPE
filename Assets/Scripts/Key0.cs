using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key0 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pickUpText;

    private bool pickUpAllowed0;
    public bool hasKey0 = false;


    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (pickUpAllowed0 && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed0 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed0 = false;
        }
    }

    private void PickUp()
    {
        hasKey0 = true;
        Destroy(gameObject);
    }
}
