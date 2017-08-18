using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public int healPoint = 20;
    private Life lifeScript;

    private void Start()
    {
        lifeScript = GameObject.Find("Label_Action_HPBar").GetComponent<Life>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //ユニティちゃんと衝突した時
        if (col.gameObject.tag == "ActionPlayer")
        {
            //LifeUpメソッドを呼び出す　引数はhealPoint
            lifeScript.LifeUp(healPoint);
            //アイテムを削除する
            Destroy(gameObject);
        }
    }
}
