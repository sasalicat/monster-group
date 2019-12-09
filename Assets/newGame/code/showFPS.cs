using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showFPS : MonoBehaviour {
    public Text txt;
	// Update is called once per frame
	void Update () {
        txt.text = "FPS: " + (1 / Time.smoothDeltaTime);

    }
}
