using UnityEngine;
using System.Collections;

public class Action_Player : MonoBehaviour
{

    public float speed = 4f;
    //********** 開始 **********//
    public GameObject mainCamera;
    //********** 終了 **********//
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    private float x;

    private bool jumptrg = false;
    public float jumpPower = 700; //ジャンプ力
    public LayerMask groundLayer; //Linecastで判定するLayer
    private bool isGrounded; //着地判定

    public GameObject bullet;
    private bool shottrg = false;

    private bool pauseflg = false;



    void Start()
    {
        x = 0;
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        //Linecastでユニティちゃんの足元に地面があるか判定
        isGrounded = Physics2D.Linecast(
        transform.position + transform.up * 1,
        transform.position - transform.up * 0.05f,
        groundLayer);
        //
        if (jumptrg && anim.GetBool("State_Jump") )
        {
            jumptrg = false;

            //着地していた時、
            //if (isGrounded)
            if(true)
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


        if (shottrg && anim.GetBool("State_Shot"))
        {
            shottrg = false;
            anim.SetTrigger("Shot");
            Instantiate(bullet, transform.position + new Vector3(0f, 1.2f, 0f), transform.rotation);
        }
    }



    void FixedUpdate()
    {
     //   float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;
            anim.SetBool("Dash", true);
            //********** 開始 **********//
            //画面中央から左に4移動した位置をユニティちゃんが超えたら
            if (transform.position.x > mainCamera.transform.position.x - 4)
            {
                //カメラの位置を取得
                Vector3 cameraPos = mainCamera.transform.position;
                //ユニティちゃんの位置から右に4移動した位置を画面中央にする
                cameraPos.x = transform.position.x + 4;
                mainCamera.transform.position = cameraPos;
            }
            
            //カメラ表示領域の左下をワールド座標に変換
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            //カメラ表示領域の右上をワールド座標に変換
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //ユニティちゃんのポジションを取得
            Vector2 pos = transform.position;
            //ユニティちゃんのx座標の移動範囲をClampメソッドで制限
            pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
            transform.position = pos;
            //********** 終了 **********//
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            anim.SetBool("Dash", false);
        }
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
}