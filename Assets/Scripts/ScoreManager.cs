using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;


public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    private ScoreSaveManager scoreSaveManager;

    public void Start()
    {
        scoreSaveManager = GetComponent<ScoreSaveManager>(); 
        if (scoreSaveManager != null)
        {
            LoadScore();
            UpdateScoreText();
        }
    }

    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;

            HandleClick(clickPosition);
        }
    }

    public void HandleClick(Vector3 position)
    {
        IncreaseScore();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
        if (scoreSaveManager != null)
        {
            scoreSaveManager.SaveScore(score);
        }
    }

    
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void LoadScore()
    {
        if (scoreSaveManager != null)
        {
            score = scoreSaveManager.LoadScore();
        }
    }

    public void ResetButton()
    {
        score = 0;
        UpdateScoreText();
    }
}
