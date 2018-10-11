using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
    
    private static ScoreController _instance;
    public static ScoreController Instance()
    {
        if(_instance == null)
        {
            _instance = new ScoreController();
        }
        return _instance;
    }

    public void Init()
    {
        currentScore = 0;
        if(PlayerPrefs.HasKey(GameConst.Prefs_HighScore))
        {
            highScore = PlayerPrefs.GetInt(GameConst.Prefs_HighScore);
        }
    }

    private int highScore;
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    private int currentScore;
    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            SaveCurrentScore();
        }
    }


    private void SaveCurrentScore()
    {
        PlayerPrefs.SetInt(GameConst.Prefs_CurrentScore, currentScore);
        if(currentScore>highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(GameConst.Prefs_HighScore, highScore);
    }
    
}
