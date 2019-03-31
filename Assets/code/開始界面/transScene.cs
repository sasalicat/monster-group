using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transScene : MonoBehaviour {
    public delegate void withNone();
    public string sceneName;
    public withNone beforeTrans;
    public void translateIt() {
        if(beforeTrans!=null)
            beforeTrans();
        SceneManager.LoadScene(sceneName);
    }
}
