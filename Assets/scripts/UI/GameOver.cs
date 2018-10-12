using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text currentScore;
    [SerializeField]
    private Text highScore;

    private void Start()
    {
        currentScore.text = ScoreController.Instance().CurrentScore.ToString();
        highScore.text = ScoreController.Instance().HighScore.ToString();
    }
    public void OnReStartGameClick()
    {
        UIManager.Instance.StartGame();
        ScoreController.Instance().Init();
    }

    public void OnReturnClick()
    {
        SceneManager.LoadScene(GameConst.scene_start);
    }
}
