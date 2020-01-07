using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour {
    public float ExistTime = 1f;
    public float timeLeft = 0f;
    public Vector2 speed;
    public EasingFunction.Ease moveEase;
    public float finalTransparent = 1;
    SpriteRenderer render;
    // Use this for initialization
    void Start () {
        timeLeft = ExistTime;
        render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            Destroy(gameObject);
        transform.position += (Vector3)(speed * Time.deltaTime * (EasingFunction.GetEasingFunction(moveEase)(0, ExistTime, (1 - timeLeft))));
        if (render != null)
        {
            Color c = render.color;
            c.a = finalTransparent + (1 - finalTransparent) * (timeLeft / ExistTime);
            render.color = c;
        }
    }
}
