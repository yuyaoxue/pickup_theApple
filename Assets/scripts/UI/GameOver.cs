using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
