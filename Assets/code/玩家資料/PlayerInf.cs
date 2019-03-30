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
    protected readonly string fileName = "player.dat";
    public PlayerInf()
    {
        army = new List<RoleRecord>();
        itemInBag = new List<int>();
    }

    public void saveInf()
    {
        var serializedData = JsonUtility.ToJson(this);
        var filePath = Application.persistentDataPath + "/"+fileName;
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(filePath);
        File.WriteAllBytes(filePath, bytes);
    }
    public void loadInf()
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
            return;
        }
        
    }
}
