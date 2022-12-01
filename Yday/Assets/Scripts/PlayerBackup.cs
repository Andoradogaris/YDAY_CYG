using System.IO;
using UnityEngine;

public class PlayerBackup : MonoBehaviour
{
    [HideInInspector]
    public int bunkerId;

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

    public void Save()
    {
        string[] content = new string[]
        {
            bunkerId.ToString()
        };

        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "\\Data\\PlayerData.txt", saveString);
        Debug.Log("Sauvegardé");
    }

    void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "\\Data\\PlayerData.txt");
        string[] content = saveString.Split(new[] { separator }, System.StringSplitOptions.None);

        bunkerId = int.Parse(content[0]);
    }
}
