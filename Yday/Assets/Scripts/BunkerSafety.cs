using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BunkerSafety : MonoBehaviour
{
    [SerializeField]
    private TMP_Text activationText;

    [SerializeField]
    private GameObject shield;

    private bool isInside;

    private void Start()
    {
        activationText.enabled = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        if(isInside && Input.GetKeyDown(KeyCode.E))
        {
            activationText.enabled = false;
            shield.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activationText.enabled = true;
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activationText.enabled = false;
            isInside = false;
        }
    }
}
