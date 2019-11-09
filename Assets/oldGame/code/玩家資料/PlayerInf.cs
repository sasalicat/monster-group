using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
public class PlayerInf  {
    //save&load 參考 https://dev.twsiyuan.com/2018/06/how-to-save-and-load-gamesaves-in-unity.html
    public int lv = 0;
    public int moneyLeft = 0;
    public List<RoleRecord> army;
    public List<int> itemInBag = new List<int>();

    
    protected static readonly string fileName = "player.dat";
    public PlayerInf()
    {
        army = new List<RoleRecord>();
        itemInBag = new List<int>();
    }

    public void saveInf()
    {

        var serializedData = JsonMapper.ToJson(this.getProfile());
        Debug.Log("serializedData:" + serializedData);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(serializedData);
        
        var filePath = Application.persistentDataPath + "/" + fileName;
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("存data到:" + filePath);
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
        PlayerInf_Profile profile= JsonMapper.ToObject<PlayerInf_Profile>(serizliedData);
        return new PlayerInf(profile);
    }
    public void printInf()
    {
        string str = "";
        int count =1;
        foreach (RoleRecord role in army) {
            str += "單位" + count + ": race:" + role.race + " unit: atk:" + role.data.Now_Attack + " hp:" + role.data.Now_Max_Life + " magic:" + role.data.Now_Mag_Reinforce + " armor:" + role.data.Now_Armor+"pos:";
            if (role.location == null)
            {
                str += "Null \n";
            }
            else
            {
                str += role.location + "\n";
            }
            count++;
        }
        Debug.Log("player level:" + lv + " money:" + moneyLeft + "\n itemInBag:"+itemInBag+"\n"+str);
    }
    public PlayerInf_Profile getProfile()
    {
        return new PlayerInf_Profile(lv,moneyLeft,army,itemInBag);
    }
    public PlayerInf(PlayerInf_Profile profile)
    {
        this.lv = profile.lv;
        this.moneyLeft = profile.moneyLeft;
        this.army = new List<RoleRecord>();
        foreach(RoleRecord_profile rp in profile.roleRecords)
        {
            this.army.Add(new RoleRecord(rp));
            army[army.Count - 1].index = (army.Count - 1);
        }
        this.itemInBag = profile.itemInBag;

    }
}
