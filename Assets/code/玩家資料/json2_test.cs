using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class json2_test : MonoBehaviour {
    class inside
    {
        public int x = 0;
        public int y = 1;
        public inside()
        {

        }
        public inside(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class test {
        public inside insid=new inside(31,66);
        public int i = 0;
        public float f = 0.1f;
        public List<int> list= new List<int>(){1,1,1,2,3,4,5};
        public void debug()
        {
            string line = "i:" + i + "f:" + f+" ";
            foreach (int item in list)
            {
                line += item;
                line += ",";
            }
            line = line + "x:" + insid.x + "y:" + insid.y;
            Debug.Log(line);
    
        }
    }
	// Use this for initialization
	void Start () {
        /*
        Dictionary<string, object> inner = new Dictionary<string, object>();
        inner["string"] = "我也是個廣東人";

        Dictionary<string, object> dicData = new Dictionary<string, object>();
        dicData["int"] = 1;
        dicData["float"] = 2f;
        dicData["double"] = 0.5;
        dicData["Dictionary"] = inner;
        //dicData["list"] = new List<int>() { 1, 1, 2, 3, 6, 7 };
        dicData["diclist"] = new List<Dictionary<string, object>>() {inner,inner};
        string str=  JsonMapper.ToJson(dicData);
         */
        List<test> list = new List<test>();
        list.Add(new test());
        list.Add(new test());
        string str = JsonMapper.ToJson(list);
        Debug.Log(str);
        //Dictionary<string, object> ans = JsonMapper.ToObject<Dictionary<string, object>>(str);
        List<test> ans = JsonMapper.ToObject<List<test>>(str);
        foreach (test t in ans)
        {
            t.debug();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
