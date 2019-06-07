using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPanel : MonoBehaviour {
    Text name;//全部手動拉去
    Text price;
    Text attribute;
    Text statement;
    public string ItemName
    {
        set
        {
            name.text = value;
        }
    }

    public int ItemPrice
    {
        set {
            price.text = "" + value;
        }
    }
    public Dictionary<byte, int> ItemAttri
    {
        set
        {

        }
    }
    public string ItemStatement
    {
        set {
            statement.text = value;
        }
    }
}
