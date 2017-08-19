using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Scout : MonoBehaviour {

    public GameObject Canvas_Scout;
    public GameObject Canvas_Select_Member;
    private GameObject Player;
    private GameObject LifeBar;

    private void Start()
    {
        LifeBar = GameObject.Find("Label_Action_HPBar");
        Player = GameObject.Find("Action_Player");
    }

    public void ButtonPush() { 
        Debug.Log("Scout pushed");
        
        if (Canvas_Scout.activeSelf == true)
        {
            Canvas_Scout.SetActive(false);

            LifeBar.GetComponent<Life>().pauseflg = false;
        }
        else
        {
            Canvas_Scout.SetActive(true);

            LifeBar.GetComponent<Life>().pauseflg = true;
        }
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;


        //SceneManager.LoadScene("Scout");
    }
}
