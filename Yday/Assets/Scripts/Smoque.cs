using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoque : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.isInsideRadioactivity = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.isInsideRadioactivity = false;
        }
    }
}
