using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberRoom_Member : MonoBehaviour
{

    public string action_type;
    private GameObject Selected_Member;
    private GameObject Selected_Memeber_inAction;
    private GameObject Text_Selected_Member;
    private Animator player_anim;
    public Sprite[] envelopeIcon = new Sprite[5];

    private GameObject Button_MemberRoom;

    public bool possesion;


    /* setter, getter付きプロパティ */

    public string id;
    public string rarity { get; set; }
    public string name { get; set; }
    public string series { get; set; }
    public string fullimgurl_0 { get; set; }
    public string fullimgurl_1 { get; set; }
    public string info { get; set; }
    public string status_s { get; set; }
    public string status_p { get; set; }
    public string status_c { get; set; }
    public string type { get; set; }


    // Use this for initialization
    void Start()
    {
        Selected_Member = GameObject.Find("Selected_MemberRoom_" + action_type);
        Selected_Memeber_inAction = GameObject.Find("Selected_Member_" + action_type);
        Text_Selected_Member = GameObject.Find("Text_MemberRoom_" + action_type);
        player_anim = GameObject.Find("Action_Player").GetComponent<Animator>();

        Button_MemberRoom = GameObject.Find("Button_Menu_Member");
    }

    void Update()
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

    /* アイコンを選択時 */
    public void OnSelectMember()
    {



        // 所有していれば選択へ、所有していなければ何もしない
        if (possesion)
        {
            Debug.Log("pushed");

            string rarity_string = "";
            if (this.rarity == "4")
            {
                rarity_string = "UR";
            }
            else if (this.rarity == "3")
            {
                rarity_string = "SSR";
            }
            else if (this.rarity == "2")
            {
                rarity_string = "SR";
            }
            else if (this.rarity == "1")
            {
                rarity_string = "R";
            }


            /* Selected Memberの表示を変更 */
            Selected_Member.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            Selected_Memeber_inAction.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            GameObject.Find("Envelope_Selected_Member_"+action_type).GetComponent<Image>().sprite = envelopeIcon[Int32.Parse(rarity)];
            GameObject.Find("envelope_Selected_MemberRoom_" + action_type).GetComponent<Image>().sprite = envelopeIcon[Int32.Parse(rarity)];


            /* Selected Memberステータスの反映 */
            SelectedMember playerObj = Selected_Member.GetComponent<SelectedMember>();
            playerObj.id = this.id;
            playerObj.rarity = this.rarity;
            playerObj.name = this.name;
            playerObj.series = this.series;
            playerObj.fullimgurl_0 = this.fullimgurl_0;
            playerObj.info = this.info;
            playerObj.status_s = this.status_s;
            playerObj.status_p = this.status_p;
            playerObj.status_c = this.status_c;
            playerObj.type = this.type;

            if (rarity_string == "R")
            {
                Text_Selected_Member.GetComponent<Text>().text = "R" + this.series;
            }
            else
            {
                Text_Selected_Member.GetComponent<Text>().text = this.series;
            }


            // ActionPlayerのStateを変更
            if (this.series == "マリン編")
            {
                player_anim.SetBool("State_Shot", true);
                player_anim.SetBool("State_China", false);
            }
            else if (this.series == "ホワイトデー編")
            {
                player_anim.SetBool("State_Fly", true);
            }
            else if (this.series == "チャイナドレス編")
            {
                player_anim.SetBool("State_Shot", false);
                player_anim.SetBool("State_China", true);
            }
            else if (action_type == "Jump")
            {
                player_anim.SetBool("State_Fly", false);
            }
            else if (action_type == "Shot")
            {
                player_anim.SetBool("State_Shot", false);
                player_anim.SetBool("State_China", false);

            }


            Debug.Log("[Selected_Member]" + playerObj.name + "(" + playerObj.series + "):" + playerObj.type + "," + playerObj.status_s + "," + playerObj.status_p + "," + playerObj.status_c);



            transform.parent.gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
