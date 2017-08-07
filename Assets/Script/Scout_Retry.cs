using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scout_Retry : MonoBehaviour {

    public GameObject Base_Scout;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPush()
    {
        Debug.Log("Scout retry");

        Base_Scout.GetComponent<Gatcha>().reload();
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;

        //SceneManager.LoadScene("Scout");
    }
}
