using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown FpsLimitator;
    [SerializeField]
    private Slider sensibility;

    [SerializeField]
    private OptionsBackup optionsBackup;

    private void Start()
    {
        InstantiateDropDown();
        sensibility.onValueChanged.AddListener(delegate { sensibilityItemSelected(sensibility); });
    }

    void InstantiateDropDown()
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
        DropdownItemSelected(FpsLimitator);

        FpsLimitator.onValueChanged.AddListener(delegate { DropdownItemSelected(FpsLimitator); });
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
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

    void sensibilityItemSelected(Slider sensibility)
    {
        optionsBackup.sensibility = sensibility.value;
    }
}
