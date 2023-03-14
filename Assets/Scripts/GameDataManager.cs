using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;
    public string PlayerName;
    public string HighScorerName;
    public int HighScore;
    private string m_SavePath;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        m_SavePath = Application.persistentDataPath + "/savefile1.json";
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    public void SaveHighScore(int highScore)
    {
        SaveData saveData = new SaveData
        {
            HighScore = highScore,
            HighScorerName = PlayerName
        };
        HighScore = highScore;
        HighScorerName = PlayerName;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(m_SavePath, json);
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }
    public void LoadGameData()
    {
        if (File.Exists(m_SavePath))
        {
            string json = File.ReadAllText(m_SavePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScorerName = data.HighScorerName;
            HighScore = data.HighScore;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScorerName;
        public string PlayerName;
    }
}
