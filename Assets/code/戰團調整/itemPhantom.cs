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
            if(obj == null)//放開後沒有點到頭像
            {
                Debug.Log("item幻影 cast");
                if (srcRoleIndex < 0) {//是背包裡的物品
                    //不做改變
                }
                else//角色上的物品
                {
                    Debug.Log("srcRoleIndex:" + srcRoleIndex + " srcItemIndex" + srcItemIndex);
                    int itemNo = dataWarehouse.main.nowData.army[srcRoleIndex].itemNos[srcItemIndex];
                    dataWarehouse.main.nowData.army[srcRoleIndex].itemNos.RemoveAt(srcItemIndex);
                    dataWarehouse.main.nowData.itemInBag.Add(itemNo);
                }
            }
        }
    }
}
