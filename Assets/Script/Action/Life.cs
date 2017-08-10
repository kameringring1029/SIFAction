using System.Collections;
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
}

