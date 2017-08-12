using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberGatcha : MonoBehaviour
{


    public Sprite[] envelopeIcon;
    public GameObject Selected_Member;
    private Animator player_anim;


    /* setter, getter付きプロパティ */
    public string id { get; set; }
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
        player_anim = GameObject.Find("Action_Player").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    /* アイコンを選択時 */
    public void OnSelectMember()
    {
        Debug.Log("pushed");

        string rarity_string = "";
        if (this.rarity == "4") {
            rarity_string = "UR";
        } else if (this.rarity == "3") {
            rarity_string = "SSR";
        } else if (this.rarity == "2") {
            rarity_string = "SR";
        } else if (this.rarity == "1") {
            rarity_string = "R";
        }


        /* Selected Memberの表示を変更 */
        Selected_Member.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        GameObject.Find("Envelope_Selected_Member").GetComponent<Image>().sprite = envelopeIcon[Int32.Parse(rarity)];


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

        if(rarity_string == "R"){
            GameObject.Find("Text_Select_Member").GetComponent<Text>().text = "R"+this.series;
        }
        else
        {
            GameObject.Find("Text_Select_Member").GetComponent<Text>().text = this.series;
        }
        
        if (this.series == "マリン編")
        {
            player_anim.SetBool("State_Shot", true);
            player_anim.SetBool("State_Fly", false);
        }
        else if (this.series == "ホワイトデー編")
        {
            player_anim.SetBool("State_Shot", false);
            player_anim.SetBool("State_Fly", true);
        }
        else
        {
            player_anim.SetBool("State_Shot", false);
            player_anim.SetBool("State_Fly", false);
        }
    

        Debug.Log("[Selected_Member]" + playerObj.name + "(" + playerObj.series + "):" + playerObj.type + "," + playerObj.status_s + "," + playerObj.status_p + "," + playerObj.status_c);


    }
}