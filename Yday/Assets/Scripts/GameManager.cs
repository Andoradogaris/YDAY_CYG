using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float health;
    public float stamina;
    private float maxHealth = 100f; 
    private float maxStamina = 100f; 
    private float looseStamina;
    private float winStamina;
    public float radioactivity;
    public float maxRadioactivity = 100f;

    
    public bool isCrouching;
    public bool isRunning;
    [HideInInspector]
    public bool canRun;

    public bool isShooting;

    private bool isDead;

    public bool isInside;



    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        radioactivity = 0f;
    }

    //UPDATE ! 

    void Update()
    {
        if (isRunning && stamina > 0)       // Gestion Stamina
        {
            UpdateStamina(-5);
            canRun = true;
        }
        else
        {
            canRun = false;
        }

        if(!isRunning && stamina < maxStamina)
        {
            UpdateStamina(5);
        }

        if(isInside) 
        {
            if(radioactivity >= 100f)
            {
                UpdateHealth(15);
            }
            else 
            {
               radioactivity += 15f; 
            }
        }else
        {
            UpdateRadioactivity();
        }

        ClampStamina();

        if(isDead)
        {
            Die();
        }
    }

    //FONCTION !

    public void UpdateHealth(float toUpdate)
    {
        health += toUpdate;
        ClampHealth();
    }

    public void UpdateStamina(float stam)
    {
        stamina += stam * Time.deltaTime;
    }

    public void UpdateRadioactivity()
    {
        radioactivity -= 1 * Time.deltaTime;
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
            isDead = true;
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

     public void ClampRadioactivity()
    {
        if (radioactivity > maxRadioactivity)
        {
            radioactivity = maxRadioactivity;
        }
        else if (radioactivity < 0f)
        {
            radioactivity = 0f;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("main_menu");
    }
}

