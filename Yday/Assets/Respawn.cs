using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    GameObject Alien;

    [SerializeField]
    private TMP_Text respawnText;

    [Header("Spawning Positions")]
    [SerializeField]
    private Vector3 pos1;
    [SerializeField]
    private Vector3 pos2;
    [SerializeField]
    private Vector3 pos3;
    [SerializeField]
    private Vector3 pos4;
    [SerializeField]
    private Vector3 pos5;
    [SerializeField]
    private Vector3 pos6;
    [SerializeField]
    private Vector3 pos7;
    [SerializeField]
    private Vector3 pos8;
    [SerializeField]
    private Vector3 pos9;
    [SerializeField]
    private Vector3 pos10;

    bool isInside;

    private void Start()
    {
        respawnText.enabled = false;
    }


    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.U))
        {
            respawnText.enabled = false;
            RespawnAlien();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respawnText.enabled = true;
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respawnText.enabled = false;
            isInside = false;
        }
    }

    void RespawnAlien()
    {
        Instantiate(Alien, pos1, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos2, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos3, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos4, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos5, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos6, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos7, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos8, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos9, Quaternion.Euler(0, 0, 0));
        Instantiate(Alien, pos10, Quaternion.Euler(0, 0, 0));
    }
}
