using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Health;
    public float Stamina;
    [SerializeField]
    private float maxHealth; 
    [SerializeField]
    private float maxStamina; 

    void Start()
    {
        Health = maxHealth;
        Stamina = maxStamina;
    }

    void Update()
    {
        ClampHealth();
        ClampStamina();
        TakeDamages();
    }









    public void TakeDamages()
    {
       if (Input.GetKey(KeyCode.A))
       {
        Health = Health - 15;
       }
    }


    public void ClampHealth()
    {
        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
        else if (Health < 0f)
        {
            Health = 0f;
        }
    }

     public void ClampStamina()
    {
        if (Stamina > maxStamina)
        {
            Stamina = maxStamina;
        }
        else if (Stamina < 0f)
        {
            Stamina = 0f;
        }
    }
}

