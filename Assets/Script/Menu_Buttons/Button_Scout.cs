using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Scout : MonoBehaviour {

    public GameObject Canvas_Scout;
    public GameObject Canvas_Select_Member;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Action_Player");
    }

    public void ButtonPush() { 
        Debug.Log("Scout pushed");
        
        if (Canvas_Scout.activeSelf == true)
        {
            Canvas_Scout.SetActive(false);

            Player.GetComponent<Action_Player>().setPauseFlg(false);
        }
        else
        {
            Canvas_Scout.SetActive(true);

            Player.GetComponent<Action_Player>().setPauseFlg(true);
        }
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;


        //SceneManager.LoadScene("Scout");
    }
}
