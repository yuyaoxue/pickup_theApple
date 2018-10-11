using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InGamePanel inGamePanel;

    [SerializeField]
    private GameOver gameoverPanel;

    public static UIManager Instance;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        inGamePanel.Init();
        gameoverPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameoverPanel.gameObject.SetActive(true);
    }

    public void ClearEvent()
    {
        inGamePanel.ClearEvent();
    }
}
