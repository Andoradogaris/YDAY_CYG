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

    [SerializeField]
    private int index;

    private PlayerBackup playerBackup;

    private void Start()
    {
        playerBackup = GameObject.Find("GameManager").GetComponent<PlayerBackup>();
        activationText.enabled = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        if(isInside && Input.GetKeyDown(KeyCode.E))
        {
            activationText.enabled = false;
            shield.SetActive(true);
            if(playerBackup.bunkerId < index)
            {
                playerBackup.bunkerId = index;
                playerBackup.Save();
            }
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
