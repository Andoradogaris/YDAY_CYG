using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{
    public GameObject mainMenu; 
    public GameObject Option;
    // public GameObject Sound;

    void Start(){
        mainMenu.SetActive(true);
        Option.SetActive(false);
       //  Sound.SetActive(false);
    }

    public void LunchGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void OptionGame(){
        mainMenu.SetActive(false);
        Option.SetActive(true);
    }   

    /*public void OptionSound(){
        Sound.SetActive(true);
        mainMenu.SetActive(false);
        Option.SetActive(false);
        Debug.Log("Erreur Attention (Sound) !");
    } */

    public void OptionController(){
        //SceneManager.LoadScene("Nom de la scene");
        Debug.Log("Erreur Attention (Controller) !");
    }

    public void BackToMain(){
        //SceneManager.LoadScene("Nom de la scene");
        mainMenu.SetActive(true);
        Option.SetActive(false);
    }

    public void OptionLanguage(){
        //SceneManager.LoadScene("Nom de la scene");
        Debug.Log("Erreur Attention (OptionLanguage) !");
    }
}

