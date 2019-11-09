using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPanel : MonoBehaviour {
    public Text name;//全部手動拉去
    public Text price;
    public Text attribute;
    public Text statement;
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

    public string ItemExplanation
    {
        set {
            attribute.text = value;
        }
    }
    public string ItemCommentary{
        set{
            statement.text = value;
        }
    }
}
