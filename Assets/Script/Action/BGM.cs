using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour {

    private AudioClip NowPlaying;
    private AudioClip NextPlay;
    public AudioClip LOVELESS_WORLD;
    public AudioClip FUTURE_STYLE;

    // Use this for initialization
    void Start () {
        NowPlaying = LOVELESS_WORLD;
        NextPlay = LOVELESS_WORLD;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeBGM()
    {

        // 現在の装備Memberの名前リストを作成
        string memberlist = "";
        memberlist = GameObject.Find("Selected_MemberRoom_Jump").GetComponent<SelectedMember>().name;
        memberlist += GameObject.Find("Selected_MemberRoom_Shot").GetComponent<SelectedMember>().name;
        memberlist += GameObject.Find("Selected_MemberRoom_Ground").GetComponent<SelectedMember>().name;


        // Unit判定してBGM決定
        string unit = checkUnit(memberlist);
        string nextplaymusic = "";

        if (unit == "2年生")
        {
            NextPlay = FUTURE_STYLE;
            nextplaymusic = "♪ Future style";
        }

        // BGMに変更があったら
        if (NextPlay != NowPlaying)
        {
            Debug.Log("change BGM to " + nextplaymusic);

            GetComponent<AudioSource>().clip = NextPlay;
            GetComponent<AudioSource>().Play();
            NowPlaying = NextPlay;
            GameObject.Find("Label_Action_BGM_Text").GetComponent<Text>().text = nextplaymusic;
        }
    }


    // 名前リストからUnitを判定
    // memberlist : ex. 穂乃果ことり海未
    // return ; ex. 2年生
    public string checkUnit(string memberlist)
    {
        Debug.Log("checkunit: " + memberlist);

        if (memberlist.Contains("穂乃果")&& memberlist.Contains("海未") && memberlist.Contains("ことり"))
        {
            return "2年生";
        }

        return "";
    }
}
