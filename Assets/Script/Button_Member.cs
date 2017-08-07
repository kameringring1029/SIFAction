using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Member : MonoBehaviour {

    public GameObject Canvas_Select_Member;

    public void ButtonPush()
    {
        Debug.Log("Member pushed");

        if(Canvas_Select_Member.activeSelf == false)
        {
            Canvas_Select_Member.SetActive(true);
        }
        else
        {
            Canvas_Select_Member.SetActive(false);
        }
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;

        //SceneManager.LoadScene("Scout");
    }
}
