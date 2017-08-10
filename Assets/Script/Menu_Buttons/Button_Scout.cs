﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Scout : MonoBehaviour {

    public GameObject Canvas_Scout;
    public GameObject Canvas_Select_Member;
    public GameObject Player;

    public void ButtonPush() { 
        Debug.Log("Scout pushed");

        Canvas_Scout.SetActive(true);
        Canvas_Select_Member.SetActive(true);
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;

        Player.GetComponent<Action_Player>().setPauseFlg(true);

        //SceneManager.LoadScene("Scout");
    }
}
