using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.isSafe = true;
        }
        else if(other.CompareTag("Alien"))
        {
            Debug.Log(other.name + "has been killed by autodefense system.");
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.isSafe = false;
        }
    }
}
