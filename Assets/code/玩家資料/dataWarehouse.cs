using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct reward
{
    public List<RoleRecord> roles;
    public List<int> itemNos;
    public int bonus;
}
public class dataWarehouse : MonoBehaviour {
    public PlayerInf nowData;
    public static dataWarehouse main;
    public delegate void withIntList(List<int> list);
    public List<RoleRecord> currentEnemy=null;
    public reward levelReward;
    private void none(List<int> arg)
    {

    }
    public delegate void withBIdict(Dictionary<byte, int> dict);
    private void none(Dictionary<byte,int> arg)
    {

    }
    public delegate void withNone();
    public void none()
    {

    }
    public delegate void withRoleRecord(RoleRecord roledata);
    public void none(RoleRecord arg)
    {

    }
    public withIntList updateBagItem;//主要用於itemInBag更新時觸發對應UI的更新(bagPanel)
    public withIntList updateNowRoleItems;//主要用於army[index].itemNos更新時觸發對應UI的更新(equipBar)
    //其實以上withIntList都可以用withNone代替的
    public withBIdict updateNowRoleAttr;
    public withBIdict denyNowRoleAttr;
    public withNone onPlayerUpdate;
    public withNone onArmyUpdate;
    //public withRoleRecord onNowRoleChange;
      
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public void createNewArchive()
    {
        Debug.Log("創建新檔案");
        nowData = new PlayerInf();
        nowData.army.Add(new RoleRecord(1));
        nowData.army[0].index = 0;
        nowData.army[0].skillNos.Add(1);
        nowData.army[0].skillNos.Add(5);
        nowData.army[0].itemNos.Add(1);
        nowData.army[0].itemNos.Add(2);
        nowData.army[0].careers = new List<int>() {5};
        nowData.army.Add(new RoleRecord(2));
        nowData.army[1].index = 1;
        nowData.army[1].skillNos.Add(1);
        nowData.army[1].skillNos.Add(8);
        nowData.army[1].skillNos.Add(10);
        nowData.army[1].careers = new List<int>() { 6 };
        nowData.army.Add(new RoleRecord(0));
        nowData.army[2].index = 2;
        nowData.army[2].skillNos = new List<int>() { 1,51};
        nowData.army[2].careers = new List<int>() { 5 };
        nowData.army[2].data.Now_Max_Life = 3000;
        nowData.army[2].data.Now_Life_Recover = 2;
        //加一點測試用的裝備
        nowData.itemInBag.Add(1);
        nowData.itemInBag.Add(2);
        nowData.itemInBag.Add(3);
        //給點初始資金
        nowData.moneyLeft = 100;
    }
    public void loadArchive() {
        Debug.Log("加載檔案");
        nowData = PlayerInf.loadInf();
        nowData.printInf();
    }
    public void Start()
    {
        Debug.Log("dataWarehouse 初始化----------------------------------------");
        Debug.Log("main為:" + main);
        DontDestroyOnLoad(this);
        updateBagItem += none;//主要用於itemInBag更新時觸發對應UI的更新(bagPanel)
        updateNowRoleItems += none;//主要用於army[index].itemNos更新時觸發對應UI的更新(equipBar)
    //其實以上withIntList都可以用withNone代替的
        updateNowRoleAttr += none;
        denyNowRoleAttr += none;
        onPlayerUpdate += none;
        onArmyUpdate += none;
}
    private void forDebug()
    {
        //nowData.
    }
}
