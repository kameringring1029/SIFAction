using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject player;
    public int speed;
    public float destroy_time;

    void Start()
    {
        //ユニティちゃんオブジェクトを取得
        player = GameObject.FindWithTag("ActionPlayer");
        //rigidbody2Dコンポーネントを取得
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        //ユニティちゃんの向いている向きに弾を飛ばす
        rigidbody2D.velocity = new Vector2(speed * player.transform.localScale.x, rigidbody2D.velocity.y);
        //画像の向きをユニティちゃんに合わせる
        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x;
        transform.localScale = temp;
        //ある時間後に消滅
        Destroy(gameObject, destroy_time);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    public void destroyself()
    {
        Destroy(gameObject);
    }
}

