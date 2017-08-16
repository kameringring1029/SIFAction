using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_MemberRoom : MonoBehaviour {

    public GameObject Canvas_MemberRoom;

    public bool possesion;

    private void Update()
    {
        // 所有状況によって表示を変更
        if (possesion)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
    }

    public void onClick()
    {
        if(possesion)
            Canvas_MemberRoom.GetComponent<Canvas>().enabled = true;
    }
}
