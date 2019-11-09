using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intbool
{
    public int no;
    public bool active;
    public intbool(int no,bool active)
    {
        this.no = no;
        this.active = active;
    }
}
public class compositePanel : MonoBehaviour {
    public GameObject strip;//手動拉取
    public GameObject mainpanel;//手動拉取 
    public GameObject itemPanel;
    public List<GameObject> objs;
	// Use this for initialization
	public void init() {
        objs = new List<GameObject>();
        List<int> unActive = new List<int>();
        for(int no =0;no<itemList.main.objects.Count;no++)
        {
            item_representation inf = itemList.main.objects[no];
            if (inf != null&& inf.Parts!=null)
            {
                bool complete = true;
                foreach (int partno in inf.Parts) {
                    if (!dataWarehouse.main.nowData.itemInBag.Contains(partno))
                    {
                        complete = false;
                        break;
                    }
                }
                if (dataWarehouse.main.nowData.moneyLeft < inf.Price)
                {
                    complete = false;
                }
                if (complete)
                {
                    GameObject obj = Instantiate(strip, mainpanel.transform);
                    obj.GetComponent<compositeStrip>().init(no, true, itemPanel,updateStrips);
                    objs.Add(obj);
                }
                else {
                    unActive.Add(no);
                }
            }
        }
        foreach(int no in unActive)
        {
            GameObject obj = Instantiate(strip, mainpanel.transform);
            obj.GetComponent<compositeStrip>().init(no, false, itemPanel);
            objs.Add(obj);
        }
	}
    public void cancer()
    {
        foreach(GameObject obj in objs)
        {
            Destroy(obj);
        }
        objs = null;
    }
    public void updateStrips()
    {
        cancer();
        init();
        
    }
}
