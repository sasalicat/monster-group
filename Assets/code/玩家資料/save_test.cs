using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

[Serializable]
public class data_
{
    int s=1;
    float f = 0.11f;
    List<int> list = new List<int>() { 0, 2, 3 };
    public data_()
    {
        s = 1;
        f = 0.11f;
       
    }
}
public class save_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string fileName = "dic.dat";
        Dictionary<string, object> outer = new Dictionary<string, object>();

        Dictionary<string, object> inner = new Dictionary<string, object>();
        //inner["list"] = new List<string>() { "one", "two", "three" };
        //outer["dic"] = inner;
        List<string> strs = new List<string>() { "a", "b", "sssss" };
        data_ data = new data_();
        //Debug.Log("dic:" + outer["dic"]);
        string json = JsonUtility.ToJson(data);
        Debug.Log("轉成的字典:" + json);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        var filePath = Application.persistentDataPath + "/" + fileName;
        File.WriteAllBytes(filePath, bytes);

        string serizliedData = (null);
        try
        {
            var str = File.ReadAllBytes(filePath);
            serizliedData = System.Text.Encoding.UTF8.GetString(str);
        }
        catch (System.IO.FileNotFoundException)
        {
            Debug.Log("讀取檔案失敗");
        }
        Debug.Log("serizlied Data:" + serizliedData);
	}

}
