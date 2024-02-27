using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name;

    public SaveData HighScore;

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveHighScore(int score)
    {
        if (score > HighScore.Score)
        {
            var data = new SaveData();
            data.Name = Name;
            data.Score = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadHighScore()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
