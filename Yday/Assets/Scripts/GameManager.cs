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
    
    public bool isCrouching;
    public bool isRunning;
    [HideInInspector]
    public bool canRun;

    public bool isShooting;

    private bool isDead;



    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
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

    public void Die()
    {
        SceneManager.LoadScene("main_menu");
    }
}

