using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Action : MonoBehaviour
{

    public GameObject Canvas_Scout;
    private GameObject Canvas_MemberRoom;
    private GameObject Canvas_MemberRoom_Jump;
    private GameObject Canvas_MemberRoom_Shot;
    private GameObject Canvas_MemberRoom_Ground;

    public GameObject Player;

    private void Start()
    {

        Canvas_MemberRoom = GameObject.Find("Canvas_MemberRoom");
        Canvas_MemberRoom_Jump = GameObject.Find("Canvas_MemberRoom_Jump");
        Canvas_MemberRoom_Shot = GameObject.Find("Canvas_MemberRoom_Shot");
        //Canvas_MemberRoom_Ground = GameObject.Find("Canvas_MemberRoom_Ground");
    }

    public void ButtonPush()
    {
        Debug.Log("Action pushed");

        Canvas_Scout.SetActive(false);
        Canvas_MemberRoom.GetComponent<Canvas>().enabled = false;
        Canvas_MemberRoom_Jump.GetComponent<Canvas>().enabled = false;
        Canvas_MemberRoom_Shot.GetComponent<Canvas>().enabled = false;
        //Canvas_MemberRoom_Ground.GetComponent<Canvas>().enabled = false;

        Player.GetComponent<Action_Player>().setPauseFlg(false);

        //SceneManager.LoadScene("Action");
    }
}