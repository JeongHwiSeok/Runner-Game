using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data
{
    public int bestscore;
}

public class DataManager : Singleton<DataManager>
{
    public Data data = new Data();
    public int score;

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");

        byte[] bytes = System.Convert.FromBase64String(jsonData);

        string code = System.Text.Encoding.UTF8.GetString(bytes);

        data = JsonUtility.FromJson<Data>(code);
    }

    public void RenewalScore()
    {
        if(data.bestscore < score)
        {
            data.bestscore = score;

            Save();
        }
    }
}
