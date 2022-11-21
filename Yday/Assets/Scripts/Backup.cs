using System.IO;
using UnityEngine;

public class Backup : MonoBehaviour
{
    public int goldCoin;
    public int silverCoin;

    public string characterName;

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
            goldCoin.ToString(),
            silverCoin.ToString(),
            characterName
        };

        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "/data.txt", saveString);
        Debug.Log("Sauvegardé");
    }

    void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/data.txt");
        string[] content = saveString.Split(new[] { separator }, System.StringSplitOptions.None);

        goldCoin = int.Parse(content[0]);
        silverCoin = int.Parse(content[1]);
        characterName = content[2];
    }
}
