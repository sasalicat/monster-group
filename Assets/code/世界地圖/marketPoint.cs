using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketPoint : MonoBehaviour {
    public GameObject bagPanel;//手動拉取
    public GameObject marketPanel;//手動拉取
    public List<int> goods;//本商店出售的貨物列表
    public void onClick()
    {
        bagPanel.SetActive(true);
        marketPanel.SetActive(true);
        marketPanel.GetComponent<marketPanel>().init(goods);
    }
}
