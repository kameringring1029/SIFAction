using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    RectTransform rt;
    bool gameover = false;

    private GameObject Player;
    public GameObject explosion;
    public GameObject damage;
    private GameObject Canvas_GameOver;

    public bool pauseflg { get; set; }

    void Start()
    {
        pauseflg = false;
        rt = GetComponent<RectTransform>();
        Player = GameObject.Find("Action_Player");
        Canvas_GameOver = GameObject.Find("Canvas_GameOver");
    }

    private void Update()
    {
        if(rt.sizeDelta.x <= 0)
        {
            if(gameover == false)
            {
                Instantiate(explosion, Player.transform.position + new Vector3(0f, 1.2f, 0f), Player.transform.rotation);
            }

            gameOver();

            if (gameover)
            {
                //Application.LoadLevel("Main");

                Canvas_GameOver.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void LifeDown(int ap)
    {
        //RectTransformのサイズを取得し、マイナスする
        rt.sizeDelta -= new Vector2(ap, 0);

        Instantiate(damage, Player.transform.position + new Vector3(0f, 1.2f, 0f), Player.transform.rotation);

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

    public void gameOver()
    {
        Destroy(Player);
        gameover = true;
    }
}

