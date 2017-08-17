using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using MembersJson;
using System;

enum Member : int { Honoka, Eli, Kotori, Umi, Rin, Maki, Nozomi, Hanayo, Nico};
enum Rarity : int { N, R, SR, SSR, UR};


public class Gatcha : MonoBehaviour {
    

    private membersinfo[] membersInfo;
    public Sprite[] envelopeIcon;

    

    // Use this for initialization
    void Start () {
        
      //  StartCoroutine(GetText());
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void reload()
    {
        StartCoroutine(GetText());
    }


    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://koke.link:3000/unity/muse_SR_UR");
        // 下記でも可
        // UnityWebRequest request = new UnityWebRequest("http://example.com");
        // methodプロパティにメソッドを渡すことで任意のメソッドを利用できるようになった
        // request.method = UnityWebRequest.kHttpVerbGET;

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                string httptext = request.downloadHandler.text;
                Debug.Log(httptext);

                membersInfo = JsonHelper.FromJson<membersinfo>(httptext);
                Debug.Log(membersInfo [10].info);



                int member_id = 10;
                for (int i = 0; i < 11; ++i)
                {
                    if (membersInfo[i].name == "穂乃果") { member_id = 0; }
                    else if (membersInfo[i].name == "絵里") { member_id = 1; }
                    else if (membersInfo[i].name == "ことり") { member_id = 2; }
                    else if (membersInfo[i].name == "海未") { member_id = 3; }
                    else if (membersInfo[i].name == "凛") { member_id = 4; }
                    else if (membersInfo[i].name == "真姫") { member_id = 5; }
                    else if (membersInfo[i].name == "希") { member_id = 6; }
                    else if (membersInfo[i].name == "花陽") { member_id = 7; }
                    else if (membersInfo[i].name == "にこ") { member_id = 8; }

                    string rarity_str = "";
                    if (membersInfo[i].rarity == "4")
                    {
                        rarity_str = "UR";
                    }
                    else if (membersInfo[i].rarity == "3")
                    {
                        rarity_str = "SSR";
                    }
                    else if (membersInfo[i].rarity == "2")
                    {
                        rarity_str = "SR";
                    }
                    else if (membersInfo[i].rarity == "1")
                    {
                        rarity_str = "R";
                    }

                    /* ガチャ結果をGUI反映 */

                   
                    GameObject.Find("Member_Gatcha" + i).GetComponent<Transform>().localScale = new Vector3(1,1,0);


                    // 特定素材がある場合はそれをload
                    GameObject.Find("Member_Gatcha" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("character/" + membersInfo[i].id);
                    if (GameObject.Find("Member_Gatcha" + i).GetComponent<Image>().sprite == null)
                    {
                        // 各レアリティ素材がある場合はそれをload
                        GameObject.Find("Member_Gatcha" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("character/muse0" + (member_id + 1) + "-" + rarity_str);
                        if (GameObject.Find("Member_Gatcha" + i).GetComponent<Image>().sprite == null)
                        {
                            // 素材がない場合は汎用R素材をload
                            GameObject.Find("Member_Gatcha" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("character/muse0" + (member_id + 1) + "-R");
                        }
                    }

                    //GameObject.Find("Button_Select_Member0").GetComponent<SpriteRenderer>().sprite = GameObject.Find("gatcha_member (" + i + ")").GetComponent<SpriteRenderer>().sprite;


                    //GameObject.Find("Text (" + i + ")").GetComponent<Text>().text = membersInfo[i].series;
                    GameObject.Find("Envelope_member" + i).GetComponent<Image>().sprite = envelopeIcon[Int32.Parse( membersInfo[i].rarity)];


                    /* 各ガチャ結果をインスタンスに代入 */
                    
                    if (GameObject.Find("Button_Selected_MemberRoom_" + membersInfo[i].id))
                    {
                        Debug.Log("Found");
                        MemberRoom_Member memberObj = GameObject.Find("Button_Selected_MemberRoom_" + membersInfo[i].id).GetComponent<MemberRoom_Member>();
                        memberObj.id = membersInfo[i].id;
                        memberObj.rarity = membersInfo[i].rarity;
                        memberObj.name = membersInfo[i].name;
                        memberObj.series = membersInfo[i].series;
                        memberObj.fullimgurl_0 = membersInfo[i].fullimgurl_0;
                        memberObj.fullimgurl_1 = membersInfo[i].fullimgurl_1;
                        memberObj.info = membersInfo[i].info;
                        memberObj.status_s = membersInfo[i].status_s;
                        memberObj.status_p = membersInfo[i].status_p;
                        memberObj.status_c = membersInfo[i].status_c;
                        memberObj.type = membersInfo[i].type;

                        memberObj.possesion = true;
                        GameObject.Find("Button_Selected_MemberRoom_" + membersInfo[i].id).transform.parent.gameObject.transform.parent.gameObject.GetComponent<Button_MemberRoom>().possesion = true;

                    }
                    
                    Debug.Log(i + " " + membersInfo[i].id + " " + membersInfo[i].rarity + "" + membersInfo[i].name + "(" + membersInfo[i].series + "):" + membersInfo[i].type + "," + membersInfo[i].status_s + "," + membersInfo[i].status_p + "," + membersInfo[i].status_c);

                }


            }
        }
    }

    public Texture2D readByBinary(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }
}
