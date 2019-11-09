using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showItemInf : MonoBehaviour {
    public int ownerIndex=-1;
    public int itemIndex=-1;
    public int itemNo = 0;
    private item_representation itemInf;
    public GameObject panel;
    public GameObject phantom;//手動拉取
    //public castItem caster;
    private bool draging = false;
   // public
    public void initInf(int no,string name, unitData data,int ownerIdx,int index)
    {
        Debug.Log("name:" + name);
        itemInf = (item_representation)System.Activator.CreateInstance(System.Type.GetType(name));
        itemInf.init(data);
        ownerIndex = ownerIdx;
        itemIndex = index;
        itemNo = no;
    }
    public void onMouseDown()
    {
        draging = true;
        panel.transform.position = transform.position;
        panel.SetActive(true);
        itemPanel itemPanel = panel.GetComponent<itemPanel>();
        itemPanel.ItemName = itemInf.itemName;
        itemPanel.ItemPrice = itemInf.Price;
        itemPanel.ItemExplanation = itemInf.Explanation;
        itemPanel.ItemCommentary = itemInf.Commentary;

    }
    public void onMouseUp()
    {
        draging = false;
        panel.SetActive(false);
    }
    public void onMouseLeave()
    {
        if (draging) {
            GameObject phant = Instantiate(phantom);
            itemPhantom script= phant.GetComponent<itemPhantom>();
            script.init(itemNo,ownerIndex,itemIndex);
            //script.caster = caster;
        }
    }
}
