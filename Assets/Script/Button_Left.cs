using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Left : MonoBehaviour {

    private Action_Player Player;


    void Start()
    {
        Player = GameObject.Find("Action_Player").GetComponent<Action_Player>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    public void OnLeftDown()
    {
        Player.setX(-1);
    }

    public void OnLeftUp()
    {
        Player.setX(0);
    }
}
