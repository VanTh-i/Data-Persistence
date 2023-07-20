using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int getHighScore { get; set; }

    private int highscore = 0;
    public int Highscore { get => highscore; set => highscore = value; }    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighScore();
    }
    void HighScore()
    {
        if (getHighScore > Highscore)
        {
            Highscore = getHighScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int Highscore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Highscore = highscore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveScoreFile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/SaveScoreFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.Highscore;
        }
    }
}
