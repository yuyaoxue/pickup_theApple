using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
    public Action<int> UpdateScore = delegate { };
    public Action ReduceBasket = delegate { };

    private static ScoreController _instance;
    public static ScoreController Instance()
    {
        if (_instance == null)
        {
            _instance = new ScoreController();
        }
        return _instance;
    }

    public void Init()
    {
        currentScore = 0;
        if (PlayerPrefs.HasKey(GameConst.Prefs_HighScore))
        {
            highScore = PlayerPrefs.GetInt(GameConst.Prefs_HighScore);
        }
        ScoreController.Instance().BasketNumber = 3;
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
            if (UpdateScore != null)
            {
                UpdateScore(currentScore);
            }
        }
    }
    private int basketNumber;
    public int BasketNumber
    {
        get
        {
            return basketNumber;
        }
        set
        {
            basketNumber = value;
            if (ReduceBasket != null)
            {
                ReduceBasket();
            }
        }
    }

    private void SaveCurrentScore()
    {
        PlayerPrefs.SetInt(GameConst.Prefs_CurrentScore, currentScore);
        if (currentScore > highScore)
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
