using System.IO;
using UnityEngine;

public class PlayerBackup : MonoBehaviour
{
    [HideInInspector]
    public int bunkerId;
    [HideInInspector]
    public int actualWeapon;
    [HideInInspector]
    public float health;
    [HideInInspector]
    public float stamina;
    [HideInInspector]
    public float radioactivity;

    private string separator = "%VALUE%";

    private void Awake()
    {
        Load();
    }

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
            bunkerId.ToString(),
            actualWeapon.ToString(),
            health.ToString(),
            stamina.ToString(),
            radioactivity.ToString()
        };

        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "PlayerData.txt", saveString);
        Debug.Log("Sauvegard�");
    }

    public void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "PlayerData.txt");
        string[] content = saveString.Split(new[] { separator }, System.StringSplitOptions.None);

        bunkerId = int.Parse(content[0]);
        actualWeapon = int.Parse(content[1]);
        health = float.Parse(content[2]);
        stamina = float.Parse(content[3]);
        radioactivity = float.Parse(content[4]);
    }
}
