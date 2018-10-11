using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private Text _textScore;
    [SerializeField]
    private GameObject[] baskets;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
        _textScore.text = "0";
        for (int i = 0; i < baskets.Length; i++)
        {
            baskets[i].SetActive(true);
        }
        InitEvent();
    }

    private void InitEvent()
    {
        ScoreController.Instance().ReduceBasket = ReduceBaskket;
        ScoreController.Instance().UpdateScore = SetTextScore;
    }

    public void ClearEvent()
    {
        ScoreController.Instance().ReduceBasket = null;
        ScoreController.Instance().UpdateScore = null;
    }


    private void SetTextScore(int score)
    {
        _textScore.text = score.ToString();
    }
    private void ReduceBaskket()
    {
        int remainNum = ScoreController.Instance().BasketNumber;
        if (remainNum >= 0 && remainNum < baskets.Length)
            baskets[remainNum].SetActive(false);
    }
}
