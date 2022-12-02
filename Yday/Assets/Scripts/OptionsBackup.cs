using System.IO;
using UnityEngine;

public class OptionsBackup : MonoBehaviour
{
    [HideInInspector]
    public int FPS;
    [HideInInspector]
    public float sensibility;
    [HideInInspector]
    public int resolution;

    private string separator = "%VALUE%";

    [SerializeField]
    Options options;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        FPS = options.FpsLimitator.value;
        sensibility = options.sensibility.value;
        resolution = options.Resolution.value;

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Load();
        }
    }

    public void Save()
    {
        string[] content = new string[]
        {
            FPS.ToString(),
            sensibility.ToString(),
            resolution.ToString()
        };

        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "\\Data\\OptionsData.txt", saveString);
        Debug.Log("Sauvegardé");
    }

    void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "\\Data\\OptionsData.txt");
        string[] content = saveString.Split(new[] { separator }, System.StringSplitOptions.None);

        options.FpsLimitator.value = int.Parse(content[0]);
        options.sensibility.value = float.Parse(content[1]);
        options.Resolution.value = int.Parse(content[2]);
    }
}
