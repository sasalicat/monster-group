using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInBattle : MonoBehaviour{
    public const float DEFAULT_OPAQUE_TIME = 0.4f;
    public const float DEFAULT_GRADIENT_TIME = 0.4f;
    protected float opaqueTimeLeft = 0;
    protected float timeLeft = 0;
    protected float lastTimeMax = 1;
    protected SpriteRenderer render;
    public delegate void noArg();
    public noArg forNextEnd;
    //public Sprite iconl;
    public void show(Sprite icon)
    {
        show(icon, DEFAULT_OPAQUE_TIME, DEFAULT_OPAQUE_TIME);
    }
    public void show(Sprite icon,float opaque_time,float left_time)
    {
        gameObject.SetActive(true);
        render.sprite = icon;
        opaqueTimeLeft = opaque_time;
        timeLeft = left_time;
        lastTimeMax = left_time;
        render.color = Color.white;
    }
    public void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (opaqueTimeLeft > 0)//第一部分不透明
        {
            opaqueTimeLeft -= Time.deltaTime;
        }
        else//第二部分漸隱
        {
            timeLeft -= Time.deltaTime;
            Color c = render.color;
            c.a = timeLeft / lastTimeMax;
            render.color = c;
            if (timeLeft <= 0)
            {
                if (forNextEnd != null)
                    forNextEnd();
                forNextEnd = null;
                gameObject.SetActive(false);
            }
        }
    }
}
