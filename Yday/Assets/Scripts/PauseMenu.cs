using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
[SerializeField] private GameObject pauseMenu;

private void Start()
{
    pauseMenu.SetActive(false);
}

void FixedUpdate()
{
    if (Input.GetKeyDown(KeyCode.P))
    {
        ActivePauseMenu();
    }
}

// private void IfPauseMenuActive()
// {
//     if (pauseMenu.SetActive = true) 
//     {
//         return true;
//     }
//     return false;
// }

private void ActivePauseMenu()
{
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
}


//     public void UnPaused()
//     {
//         pauseMenu.SetActive(false);
//         Time.timeScale = 1f;
//         Cursor.visible = false;
//         Cursor.lockState = CursorLockMode.Locked;
//     }
}