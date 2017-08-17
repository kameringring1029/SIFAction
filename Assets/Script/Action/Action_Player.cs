using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Action_Player : MonoBehaviour
{

    public float speed = 4f;
    public GameObject mainCamera;
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    private float x;

    private bool jumptrg = false;
    public float jumpPower = 700; //ジャンプ力
    public LayerMask groundLayer; //Linecastで判定するLayer
    private bool isGrounded; //着地判定

    public GameObject bullet;
    public GameObject bullet_card;
    public GameObject impact;

    private bool shottrg = false;

    private bool pauseflg = false;
    private bool pauseflg_player = false;

    public int loveca { set; get; }



    void Start()
    {
        x = 0;
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        loveca = 53;
        GameObject.Find("Loveca_num").GetComponent<Text>().text = "" + loveca;
    }



    void Update()
    {
        if (!pauseflg_player)
        {

            //Jumpボタン
            if (jumptrg)
            {
                jumptrg = false;

                //Linecastで足元に地面があるか判定
                isGrounded = Physics2D.Linecast(
                transform.position + transform.up * 1,
                transform.position - transform.up * 0.05f,
                groundLayer);

                //着地していた時、
                if (isGrounded || anim.GetBool("State_Fly"))
                {
                    //Dashアニメーションを止めて、Jumpアニメーションを実行
                    anim.SetBool("Dash", false);
                    anim.SetTrigger("Jump");
                    //着地判定をfalse
                    isGrounded = false;
                    //AddForceにて上方向へ力を加える
                    rigidbody2D.AddForce(Vector2.up * jumpPower);
                }
            }
            //上下への移動速度を取得
            float velY = rigidbody2D.velocity.y;
            //移動速度が0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true : false;
            //移動速度が-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true : false;
            //結果をアニメータービューの変数へ反映する
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isFalling", isFalling);

            if (isGrounded)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }


            // Shotボタン
            if (shottrg)
            {
                shottrg = false;
                anim.SetTrigger("Shot");

                // マリン編装備時
                if (anim.GetBool("State_Shot"))
                {
                    Instantiate(bullet, transform.position + new Vector3(0f, 1.2f, 0f), transform.rotation);
                }
                // チャイナドレス編装備時
                else if (anim.GetBool("State_China"))
                {
                    // Playerを一時停止しImpact発生
                    anim.SetBool("Dash", false);
                    pauseflg_player = true;
                    Instantiate(impact, transform.position + new Vector3(2.0f * transform.localScale.x, 1.2f, 0f), transform.rotation);
                }
                // 通常状態時, bulletがフィールドにない場合（フィールドに2つ以上発生しないように）
                else if (!(GameObject.Find("bullet_card(Clone)")))
                {
                    Instantiate(bullet_card, transform.position + new Vector3(0f, 1.2f, 0f), transform.rotation);
                }
            }

        }
    }



    void FixedUpdate()
    {

        if (!pauseflg_player)
        {

            if (x != 0)
            {
                rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
                Vector2 temp = transform.localScale;
                temp.x = x;
                transform.localScale = temp;
                anim.SetBool("Dash", true);
                //画面中央から左に4移動した位置を超えたら
                if (transform.position.x > mainCamera.transform.position.x - 4)
                {
                    //カメラの位置を取得
                    Vector3 cameraPos = mainCamera.transform.position;
                    //位置から右に4移動した位置を画面中央にする
                    cameraPos.x = transform.position.x + 4;
                    mainCamera.transform.position = cameraPos;
                }

                //カメラ表示領域の左下をワールド座標に変換
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                //カメラ表示領域の右上をワールド座標に変換
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
                //ポジションを取得
                Vector2 pos = transform.position;
                //x座標の移動範囲をClampメソッドで制限
                pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
                transform.position = pos;
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                anim.SetBool("Dash", false);
            }

        }
    }


    // チャイナ反動
    public void recoilChina()
    {
        rigidbody2D.velocity = new Vector2(transform.localScale.x * (-1) * speed, rigidbody2D.velocity.y);
    }

    public void setX(float x)
    {
        this.x = x;
    }

    public void setJumpTrg()
    {
        this.jumptrg = true;
    }

    public void setShotTrg()
    {
        this.shottrg = true;
    }

    public void setPauseFlg(bool flg)
    {
        this.pauseflg = flg;
    }

    public bool getPauseFlg()
    {
        return pauseflg;
    }

    public void setPauseFlgPlayerFalse()
    {
        this.pauseflg_player = false;
    }
}