using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MembersJson
{
    

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.members;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] members;
        }
    }



    [System.Serializable]
    public class membersinfo
    {
        public string id;
        public string rarity;
        public string name;
        public string series;
        public string fullimgurl_0;
        public string fullimgurl_1;
        public string info;
        public string status_s;
        public string status_p;
        public string status_c;
        public string type;
    }


}

