using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {
    public float totalTime = 0;
    public float timeLeft = 0;
    public SpriteRenderer img;
    public void initSetting(float totalTime)
    {
        this.totalTime = totalTime;
        this.timeLeft = totalTime;
        img = GetComponent<SpriteRenderer>();
    }	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        img.color = new Color(1, 1, 1, timeLeft / totalTime);
	}
}
