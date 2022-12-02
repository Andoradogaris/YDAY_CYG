using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public TMP_Dropdown FpsLimitator;
    public Slider sensibility;
    public TMP_Dropdown Resolution;

    [SerializeField]
    private OptionsBackup optionsBackup;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InstantiateFpsLimitator();
        InstantiateSensibility();
        InstantiateResolution();
    }

    void InstantiateFpsLimitator()
    {
        FpsLimitator.options.Clear();

        List<string> fpsItems = new List<string>();
        fpsItems.Add("30 FPS");
        fpsItems.Add("60 FPS");
        fpsItems.Add("144 FPS");
        fpsItems.Add("165 FPS");
        fpsItems.Add("240 FPS");
        fpsItems.Add("No Limit");

        foreach (var item in fpsItems)
        {
            FpsLimitator.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }

        FpsLimitator.value = Screen.currentResolution.refreshRate;
        FpsLimitatorItemSelected(FpsLimitator);

        FpsLimitator.onValueChanged.AddListener(delegate { FpsLimitatorItemSelected(FpsLimitator); });
    }

    void FpsLimitatorItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        if(index == 0)
        {
            index = 30;
            Application.targetFrameRate = index;
        }
        else if (index == 1)
        {
            index = 60;
            Application.targetFrameRate = index;
        }
        else if (index == 2)
        {
            index = 144;
            Application.targetFrameRate = index;
        }
        else if (index == 3)
        {
            index = 165;
            Application.targetFrameRate = index;
        }
        else if (index == 4)
        {
            index = 240;
            Application.targetFrameRate = index;
        }
        else if (index == 5)
        {
            index = -1;
            Application.targetFrameRate = index;
        }
        optionsBackup.FPS = index;
    }

    void InstantiateSensibility()
    {
        sensibility.onValueChanged.AddListener(delegate { sensibilityItemSelected(sensibility); });
    }

    void sensibilityItemSelected(Slider sensibility)
    {
        optionsBackup.sensibility = sensibility.value;
    }

    void InstantiateResolution()
    {
        Resolution.options.Clear();

        List<string> fpsItems = new List<string>();
        fpsItems.Add("1020 x 768");
        fpsItems.Add("1280 x 800");
        fpsItems.Add("1280 x 1024");
        fpsItems.Add("1600 x 1200");
        fpsItems.Add("1680 x 1050");
        fpsItems.Add("1920 x 1080");
        fpsItems.Add("2560 x 1600");

        foreach (var item in fpsItems)
        {
            Resolution.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }

        ResolutionItemSelected(Resolution);

        Resolution.onValueChanged.AddListener(delegate { ResolutionItemSelected(Resolution); });
    }

    void ResolutionItemSelected(TMP_Dropdown Resolution)
    {
        int index = Resolution.value;
        if (index == 0)
        {
            Screen.SetResolution(1020, 768, true);
        }
        else if (index == 1)
        {
            Screen.SetResolution(1280, 800, true);
        }
        else if (index == 2)
        {
            Screen.SetResolution(1280, 1024, true);
        }
        else if (index == 3)
        {
            Screen.SetResolution(1600, 1200, true);
        }
        else if (index == 4)
        {
            Screen.SetResolution(1680, 1050, true);
        }
        else if (index == 5)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (index == 6)
        {
            Screen.SetResolution(2560, 1600, true);
        }
        optionsBackup.resolution = index;
    }
}
