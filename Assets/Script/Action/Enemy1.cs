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
    //メインカメラのタグ名　constは定数(絶対に変わらない値)
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに映っているかの判定
    private bool _isRendered = false;
    private bool pauseflag = false;

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
            else if(col.tag == "Impact")
            {
                Instantiate(explosion, transform.position, transform.rotation);

                // ふっとび
                if (speed > 0) speed = -1;
                else speed = 1;
                speed = speed * 10;
                Destroy(gameObject, 2);

                // Bullet化
                gameObject.tag = "Bullet";
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            }
            // Bullet化したとき時の挙動
            else if (col.gameObject.tag == "Enemy" && gameObject.tag == "Bullet")
            {
                Destroy(gameObject);
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