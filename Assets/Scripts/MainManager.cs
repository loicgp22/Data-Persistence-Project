using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    //  Highscore variables to save
    public string playerNameBest;
    public int scoreBest;

    //  HOW TO DISPLAY TEXT FROM AN INPUT FIELD USING C# UNITY TUTORIAL
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadAllData();
    }

    public class SaveData
    {
        public string playerName;
        public string playerNameBest;
        public int scoreBest;
    }

    private SaveData saveData = new SaveData();

    public void SaveAllData()
    {
        saveData.playerName = playerName;
        saveData.playerNameBest = playerNameBest;
        saveData.scoreBest = scoreBest;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAllData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);

            playerName = saveData.playerName;
            playerNameBest = saveData.playerNameBest;
            scoreBest = saveData.scoreBest;
        }
    }

    /*
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveScoreBest()
    {   
        SaveData data = new SaveData();
        data.scoreBest = scoreBest;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveNameBest()
    {
        SaveData data = new SaveData();
        data.playerNameBest = playerNameBest;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }

    public void LoadScoreBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scoreBest = data.scoreBest;
        }
    }

    public void LoadNameBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameBest = data.playerNameBest;
        }
    }
    */
    public void ClearData()
    {
        playerNameBest = "";
        scoreBest = 0;
        SaveAllData();
    }
}
