﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void LifeDown(int ap)
    {
        //RectTransformのサイズを取得し、マイナスする
        rt.sizeDelta -= new Vector2(ap, 0);
    }

    public void LifeUp(int hp)
    {
        //RectTransformのサイズを取得し、プラスする
        rt.sizeDelta += new Vector2(hp, 0);
        //最大値を超えたら、最大値で上書きする
        if (rt.sizeDelta.x > 160f)
        {
            rt.sizeDelta = new Vector2(160f, 15f);
        }
    }
}

