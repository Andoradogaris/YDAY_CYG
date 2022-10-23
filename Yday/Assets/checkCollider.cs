using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollider : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
