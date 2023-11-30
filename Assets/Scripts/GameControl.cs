using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    public string _playerName;
    public int _bestScore;
    public string _bestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

    }

    [Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int score;
    }

    public void SaveScore(string bestPlayer, int score)
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.score = score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _bestPlayer = data.bestPlayer;
            _bestScore = data.score;
        }
    }
}
