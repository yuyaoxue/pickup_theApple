using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public AppleTree tree;
    private int numBaskets = 1;
    public float basketBottomY = -16f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;
    public static ApplePicker Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        Init();
    }
    public void Init()
    {
        Init_Basket();
        tree.Init();
        ScoreController.Instance().Init();
    }
    private void Init_Basket()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        // 消除所有下落中的苹果
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        //如果 basketList 的长度为 0，游戏结束
        if (ScoreController.Instance().BasketNumber > 0)
        {
            ScoreController.Instance().BasketNumber--;
        }

        if(ScoreController.Instance().BasketNumber == 0)
        {
            UIManager.Instance.GameOver();
            UIManager.Instance.ClearEvent();
        }
    }
}
