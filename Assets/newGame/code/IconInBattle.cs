using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInBattle : MonoBehaviour{
    public const float DEFAULT_SHOW_TIME = 0.5f;
    protected float timeLeft = 0;
    protected float lastTimeMax = 1;
    protected SpriteRenderer render;
    public delegate void noArg();
    public noArg forNextEnd;
    //public Sprite iconl;
    public void show(Sprite icon)
    {
        show(icon, DEFAULT_SHOW_TIME);
    }
    public void show(Sprite icon,float second)
    {
        gameObject.SetActive(true);
        render.sprite = icon;
        timeLeft = second;
        lastTimeMax = second;
    }
    public void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public void Update()
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
