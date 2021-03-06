﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // 用来初始化苹果实例的预设
    public GameObject applePrefab;
    // 苹果树移动的速度，单位 米/秒
    public float speed = 1f;
    // 苹果树的活动区域，到达边界时则改变方向
    public float leftAndRightEdge = 10;
    // 苹果出现的时间间隔
    public float secondsBetweenAppleDrops = 1f;
    // 苹果树改变方向的概率
    private float chanceToChange1Directions = 0.01f;

    public void Init()
    {
        // 初始化	
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
        UIManager.Instance.StartGame();
    }

    private void Update()
    {
        // 基本运动

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //改变方向

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);// 向右运动
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);// 向左运动
        }
    }

    private void FixedUpdate()
    {
        // 随机改变运动方向
        if (Random.value < chanceToChange1Directions)
        {
            speed *= -1;// 改变方向
        }
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
}
