using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPhantom : MonoBehaviour {
    int srcRoleIndex;
    int srcItemIndex;

    public void init(int no,int sr_idx,int si_idx)
    {
        GetComponent<SpriteRenderer>().sprite = ImageList.main.itemIcon[no];
        srcRoleIndex = sr_idx;
        srcItemIndex = si_idx;
    }
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
            GameObject obj =  castItem.main.cast();
            if (obj == null)//放開後沒有點到頭像
            {
                Debug.Log("item幻影 cast");
                if (srcRoleIndex < 0)
                {//是背包裡的物品
                    //不做改變
                }
                else//角色上的物品
                {
                    Debug.Log("srcRoleIndex:" + srcRoleIndex + " srcItemIndex" + srcItemIndex);
                    int itemNo = dataWarehouse.main.nowData.army[srcRoleIndex].itemNos[srcItemIndex];
                    PlayerInf player = dataWarehouse.main.nowData;
                    player.army[srcRoleIndex].itemNos.RemoveAt(srcItemIndex);
                    player.itemInBag.Add(itemNo);
                    dataWarehouse.main.updateBagItem(player.itemInBag);
                    dataWarehouse.main.updateNowRoleItems(player.army[srcRoleIndex].itemNos);
                }
            }
            else if (obj.tag == "itemBar")
            {
                if (srcRoleIndex < 0)
                {//是背包裡的物品,將這個背包裡的物品裝備到角色身上
                    equipBar bar = obj.GetComponent<equipBar>();
                    PlayerInf player = dataWarehouse.main.nowData;
                    int itemNo = player.itemInBag[srcItemIndex];
                    player.itemInBag.RemoveAt(srcItemIndex);
                    bar.role.itemNos.Add(itemNo);
                    //player.army[bar.role.index].itemNos.Add(itemNo);
                    dataWarehouse.main.updateBagItem(player.itemInBag);
                    dataWarehouse.main.updateNowRoleItems(bar.role.itemNos);
                }
                else//角色上的物品
                {
                    //不做改變
                }
            }
            else if (obj.tag == "itemIcon") {
                showItemInf inf = obj.GetComponent<showItemInf>();
                if (inf.ownerIndex == srcRoleIndex)//包括背包的-1如果所有者相同則只是自己換自己的沒事會發生
                {

                }
                else if (srcRoleIndex < 0)//如果是從背包裏掏出來的裝備
                {
                    PlayerInf player = dataWarehouse.main.nowData;
                    int itemNo = player.itemInBag[srcItemIndex];
                    player.itemInBag[srcItemIndex] = inf.itemNo;
                    player.army[inf.ownerIndex].itemNos[inf.itemIndex] = itemNo;
                    dataWarehouse.main.updateBagItem(player.itemInBag);
                    dataWarehouse.main.updateNowRoleItems(player.army[inf.ownerIndex].itemNos);
                }
                else {//從角色身上掏出的東西
                    PlayerInf player = dataWarehouse.main.nowData;
                    int itemNo = player.army[srcRoleIndex].itemNos[srcItemIndex];
                    player.army[srcRoleIndex].itemNos[srcItemIndex] = inf.itemNo;
                    player.itemInBag[inf.itemIndex] = itemNo;
                    dataWarehouse.main.updateBagItem(player.itemInBag);
                    dataWarehouse.main.updateNowRoleItems(player.army[srcRoleIndex].itemNos);
                }
            }
        }
    }
}
