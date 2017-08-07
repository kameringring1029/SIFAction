using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Member : MonoBehaviour
{
    
    public GameObject Canvas_Select_Member;

    public void ButtonPush()
    {
        Debug.Log("Member pushed");

        if (Canvas_Select_Member.activeSelf == true)
        {
            Canvas_Select_Member.SetActive(false);

        }
        else
        {
            Canvas_Select_Member.SetActive(true);

        }
    }
}