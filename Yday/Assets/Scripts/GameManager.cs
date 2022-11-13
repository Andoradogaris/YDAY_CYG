using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float health;
    private float maxHealth = 100f;
    public float stamina;
    private float maxStamina = 100f; 

    public float radioactivity;
    public float maxRadioactivity = 100f;

    
    public bool isCrouching;
    public bool isRunning;
    [HideInInspector]
    public bool canRun;

    public bool isShooting;

    private bool isDead;

    public bool isInside;

    [Header("UI")]
    [SerializeField]
    private TMP_Text DieText;
    [SerializeField]
    private TMP_Text AmmoText;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        DieText.enabled = false;
    } 

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


        if (isInside) 
        {
            if(radioactivity >= 100f)
            {
                UpdateHealth(-15);
            }
            else 
            {
                radioactivity += 15 * Time.deltaTime;
            }
        }
        else
        {
            UpdateRadioactivity();
        }
        ClampRadioactivity();

        if (isDead)
        {
            Die();
        }
    }

    public void UpdateHealth(float toUpdate)
    {
        health += toUpdate * Time.deltaTime;
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

    public void UpdateAmmo(int actual, int global)
    {
        AmmoText.text = actual + " / " + global;
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
        DieText.enabled = true;
        StartCoroutine(GoToMenu());
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("main_menu");
    }
}

