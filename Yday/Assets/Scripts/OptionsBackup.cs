using System.IO;
using UnityEngine;

public class OptionsBackup : MonoBehaviour
{
    [HideInInspector]
    public int FPS;
    [HideInInspector]
    public float sensibility;

    private string separator = "%VALUE%";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Load();
        }
    }

    void Save()
    {
        string[] content = new string[]
        {
            FPS.ToString(),
            sensibility.ToString()
        };

        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "/OptionsData.txt", saveString);
        Debug.Log("Sauvegardé");
    }

    void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/OptionsData.txt");
        string[] content = saveString.Split(new[] { separator }, System.StringSplitOptions.None);

        FPS = int.Parse(content[0]);
        sensibility = float.Parse(content[1]);
    }
}
