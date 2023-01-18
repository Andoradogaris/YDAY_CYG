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
        else
        {
            Debug.Log(other.name + "has been killed by autodefense system.");
            other.GetComponent<IAController_V2>().TakeDamage(1000000);
        }
        Debug.Log("test");
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.isSafe = false;
        }
    }
}
