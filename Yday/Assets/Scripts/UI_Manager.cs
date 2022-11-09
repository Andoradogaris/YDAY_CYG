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
        SceneManager.LoadScene("mainJeux");
        Debug.Log("Erreur Attention (LunchGame) !");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Erreur Attention (QuiGame) !");
    }

    public void OptionGame(){
        mainMenu.SetActive(false);
        Option.SetActive(true);
        
        Debug.Log("Erreur Attention (OptionGame) !");
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
        Debug.Log("Erreur Attention (Back) !");
    }

    public void OptionLanguage(){
        //SceneManager.LoadScene("Nom de la scene");
        Debug.Log("Erreur Attention (OptionLanguage) !");
    }
}

