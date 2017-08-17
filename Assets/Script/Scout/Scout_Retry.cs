using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        // ラブカストーン所有数が50以上のとき50消費して勧誘実施
        if (GameObject.Find("Action_Player").GetComponent<Action_Player>().loveca >= 50)
        {
            Debug.Log("Scout retry");
            int lovecanum = GameObject.Find("Action_Player").GetComponent<Action_Player>().loveca;
            lovecanum -= 50;
            GameObject.Find("Loveca_num").GetComponent<Text>().text = "" + lovecanum;
            Base_Scout.GetComponent<Gatcha>().reload();
        }
    }
}
