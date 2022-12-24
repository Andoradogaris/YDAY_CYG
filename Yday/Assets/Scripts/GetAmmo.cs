using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    [SerializeField]
    Gun gun;
    [SerializeField]
    AK aK;

    [SerializeField] private int addAmmo;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(gameManager.playerController.weaponIndex == 1)
            {
                gun.GetAmmo(addAmmo);
            }
            else if(gameManager.playerController.weaponIndex == 0)
            {
                aK.GetAmmo(addAmmo);
            }
        }
    }
}