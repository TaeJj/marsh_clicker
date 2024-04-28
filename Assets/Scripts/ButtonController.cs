using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public ScoreManager scoreManager;

    
    public void ResetScore()
    {
        if (scoreManager != null)
        {
            scoreManager.ResetButton();
        }
        else
        {
            UnityEngine.Debug.LogError("ScoreManager is not assigned!");
        }
    }
}
