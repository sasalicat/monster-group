using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour {
    public SpriteRenderer bar = null;
    private float percentage=1;
    protected const float FULL_X = .0f;
    protected const float ZERO_X = -3.39f;
    public float Percentage
    {
        set
        {
            percentage = value;
            if(value > 1f)
            {
                percentage = 1f;
            }
            Debug.Log(transform.parent.name+ "設置血量:" + percentage);
            bar.transform.localPosition = new Vector2(ZERO_X + (FULL_X - ZERO_X) * percentage, 0);
        }
        get
        {
            return percentage;
        }
    }
    public Color HpColor
    {
        set {
            bar.color = value;
        }
        get
        {
            return bar.color;
        }
    }
    void Start()
    {
        //Percentage = 0.5f;
    }
}
