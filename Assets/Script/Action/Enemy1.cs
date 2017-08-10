using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {


    Rigidbody2D rigidbody2D;
    public int speed = -3;
    public GameObject explosion;
    public int attackPoint = 10;
   // public GameObject item;

    public GameObject Player;

    private Life lifeScript;
    //********** 開始 **********//
    //メインカメラのタグ名　constは定数(絶対に変わらない値)
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに映っているかの判定
    private bool _isRendered = false;
    //********** 終了 **********//

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        lifeScript = GameObject.FindGameObjectWithTag("HP").GetComponent<Life>();
    }

    void Update()
    {
        if (_isRendered && !(Player.GetComponent<Action_Player>().getPauseFlg()))
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered)
        {
            if (col.tag == "Bullet")
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                if (Random.Range(0, 4) == 0)
                {
                    //Instantiate(item, transform.position, transform.rotation);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ActionPlayer")
        {
            lifeScript.LifeDown(attackPoint);
            transform.position = new Vector3(transform.position.x+1,transform.position.y,transform.position.z);
        }
    }
    //Rendererがカメラに映ってる間に呼ばれ続ける
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}