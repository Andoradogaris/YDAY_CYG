using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float health;
    public float stamina;
    [SerializeField] private float maxHealth; 
    [SerializeField] private float maxStamina; 
    public float looseStamina;
    public float winStamina;
    




    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
    }

    //UPDATE ! 

    void Update()
    {


        ClampHealth();              //Encadrement des Variables
        ClampStamina();

        if (Input.GetKeyDown(KeyCode.L))  //Degats subit
        {
            TakeDamages(15);
        }

        if (Input.GetKeyDown(KeyCode.O)) //Heal 
        {
            TakeHealth(15);
        }

            if (Input.GetKey(KeyCode.LeftShift))       // Gestion Stamina
            {
                stamina -= looseStamina * Time.deltaTime;
            }
            else
            {
                stamina += winStamina * Time.deltaTime;
            }
    }

    //FONCTION !


    public void TakeDamages(float damages)
    {
        health -= damages;
    }

     public void TakeHealth(float heal)
    {
        health += heal;
    }

    public void ClampHealth()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0f)
        {
            health = 0f;
        }
    }

     public void ClampStamina()
    {
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        else if (stamina < 0f)
        {
            stamina = 0f;
        }
    }
}

