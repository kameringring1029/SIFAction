using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Action : MonoBehaviour
{

    public GameObject Canvas_Scout;

    public void ButtonPush()
    {
        Debug.Log("Action pushed");

        Canvas_Scout.SetActive(false);

        //SceneManager.LoadScene("Action");
    }
}