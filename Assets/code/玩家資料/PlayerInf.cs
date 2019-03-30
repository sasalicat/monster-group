using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class PlayerInf  {
    //save&load 參考 https://dev.twsiyuan.com/2018/06/how-to-save-and-load-gamesaves-in-unity.html
    public int lv = 0;
    public int moneyLeft = 0;
    public List<RoleRecord> army;
    public List<int> itemInBag;
    protected static readonly string fileName = "player.dat";
    public PlayerInf()
    {
        army = new List<RoleRecord>();
        itemInBag = new List<int>();
    }

    public void saveInf()
    {
        var serializedData = JsonUtility.ToJson(this);
        Debug.Log("serializedData:" + serializedData);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(serializedData);
        
        var filePath = Application.persistentDataPath + "/" + fileName;
        File.WriteAllBytes(filePath, bytes);
    }
    public static PlayerInf loadInf()
    {
        var filePath = Application.persistentDataPath + "/" + fileName;
        string serizliedData = (null);
        try
        {
            var bytes = File.ReadAllBytes(filePath);
            serizliedData=System.Text.Encoding.UTF8.GetString(bytes);
        }
        catch (System.IO.FileNotFoundException)
        {
            return null;
        }
        Debug.Log("serizlied Data:" + serizliedData);
        return JsonUtility.FromJson<PlayerInf>(serizliedData);
    }
    public void printInf()
    {
        Debug.Log("player level:" + lv + " money:" + moneyLeft + "\n army type:" + army.GetType() +"size:"+army.Count+ "\n itemInBag:"+itemInBag);
    }
}
