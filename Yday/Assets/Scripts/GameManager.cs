using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float health;
    private float maxHealth = 100;
    public float stamina;
    private float maxStamina = 100f; 

    public float radioactivity;
    private float maxRadioactivity = 100f;

    
    public bool isCrouching;
    public bool isRunning;
    [HideInInspector]
    public bool canRun;
    public bool isShooting;
    [HideInInspector]
    public bool isDead;
    public bool isInsideRadioactivity;
    public bool isSafe;

    [SerializeField]
    private PlayerController playerController;

    [Header("UI")]
    [SerializeField]
    private TMP_Text DieText;
    [SerializeField]
    private TMP_Text AmmoText;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image staminaBar;
    [SerializeField]
    private Image radioactivityBar;

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
        if (isRunning && stamina > 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))       // Gestion Stamina
        {
            UpdateStamina(-5);
            canRun = true;
        }
        else
        {
            UpdateStamina(5);
            canRun = false;
        }
        ClampStamina();


        if (isInsideRadioactivity) 
        {
            if(radioactivity >= 100f)
            {
                UpdateHealth(-15);
            }
            else 
            {
                radioactivity += 15 * Time.deltaTime;
            }
            UpdateRadioactivity();
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
        UpdateUI();
    }

    public void UpdateStamina(float stam)
    {
        stamina += stam * Time.deltaTime;
        UpdateUI();
    }

    public void UpdateRadioactivity()
    {
        radioactivity -= 1 * Time.deltaTime;
        UpdateUI();
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

    public void UpdateUI()
    {
        healthBar.fillAmount = health / maxHealth;
        staminaBar.fillAmount = stamina / maxStamina;
        radioactivityBar.fillAmount = radioactivity / maxRadioactivity;
    }

    public void Die()
    {
        DieText.enabled = true;
        StartCoroutine(GoToMenu());
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("main_menu");
    }
}

