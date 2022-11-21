using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreen;
    [SerializeField]
    private Slider slider;

    public GameObject mainMenu; 
    public GameObject Option;
    // public GameObject Sound;

    void Start(){
        mainMenu.SetActive(true);
        Option.SetActive(false);
        //  Sound.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelAsync(sceneIndex));
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

    IEnumerator LoadLevelAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            Debug.Log(progress * 100 + " %");
            yield return null;
        }
    }
}

