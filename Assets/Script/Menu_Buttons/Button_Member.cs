using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Member : MonoBehaviour
{
    
    private GameObject Canvas_MemberRoom;
    private GameObject Canvas_MemberRoom_Jump;
    private GameObject Canvas_MemberRoom_Shot;
    private GameObject Canvas_MemberRoom_Ground;
    private GameObject Player;
    private GameObject LifeBar;


    private void Start()
    {
        Player = GameObject.Find("Action_Player");
        LifeBar = GameObject.Find("Label_Action_HPBar");

        Canvas_MemberRoom = GameObject.Find("Canvas_MemberRoom");
        Canvas_MemberRoom_Jump = GameObject.Find("Canvas_MemberRoom_Jump");
        Canvas_MemberRoom_Shot = GameObject.Find("Canvas_MemberRoom_Shot");
        Canvas_MemberRoom_Ground = GameObject.Find("Canvas_MemberRoom_Ground");


    }

    public void ButtonPush()
    {
        Debug.Log("Member pushed");

        if (Canvas_MemberRoom.GetComponent<Canvas>().enabled)
        {
            Canvas_MemberRoom.GetComponent<Canvas>().enabled=false;
            Canvas_MemberRoom_Jump.GetComponent<Canvas>().enabled = false;
            Canvas_MemberRoom_Shot.GetComponent<Canvas>().enabled = false;
            Canvas_MemberRoom_Ground.GetComponent<Canvas>().enabled = false;

            LifeBar.GetComponent<Life>().pauseflg =false;
        }
        else
        {
            Canvas_MemberRoom.GetComponent<Canvas>().enabled = true;
            Canvas_MemberRoom_Jump.GetComponent<Canvas>().enabled = true;
            Canvas_MemberRoom_Shot.GetComponent<Canvas>().enabled = true;
            Canvas_MemberRoom_Ground.GetComponent<Canvas>().enabled = true;

            LifeBar.GetComponent<Life>().pauseflg = true;
        }
    }
}