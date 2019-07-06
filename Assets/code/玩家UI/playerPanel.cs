using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerPanel : MonoBehaviour {
    public Text lv_num;
    public Text gold_num;
	// Use this for initialization
	void Start () {
        lv_num.text = "" + dataWarehouse.main.nowData.lv;
        gold_num.text = "" + dataWarehouse.main.nowData.moneyLeft;
        dataWarehouse.main.onPlayerUpdate += updatePlayer;
	}
    void updatePlayer()
    {
        lv_num.text = "" + dataWarehouse.main.nowData.lv;
        gold_num.text = "" + dataWarehouse.main.nowData.moneyLeft;
    }
    public void ActivePanel()
    {
        gameObject.SetActive(true);
    }
}
