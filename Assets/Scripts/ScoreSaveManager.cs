using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

public class ScoreSaveManager : MonoBehaviour
{
    private const string SAVE_PATH = "/score.json";

    public void SaveScore(int score)
    {
        ScoreData scoreData = new ScoreData(score);
        string json = JsonUtility.ToJson(scoreData);
        File.WriteAllText(UnityEngine.Application.persistentDataPath + SAVE_PATH, json);
    }

    public int LoadScore()
    {
        string path = UnityEngine.Application.persistentDataPath + SAVE_PATH;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);
            return scoreData.score;
        }
        else
        {
            return 0;
        }
    }

    public void ResetScore()
    {
        string path = UnityEngine.Application.persistentDataPath + SAVE_PATH;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
