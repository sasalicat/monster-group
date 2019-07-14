using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transScene : MonoBehaviour {
    public delegate void withNone();
    public string sceneName;
    public withNone beforeTrans;
    //List<RoleRecord> enermyData;
    
    public void translateIt() {
        Debug.Log("translate It 被觸發");
        if(beforeTrans!=null)
            beforeTrans();
        SceneManager.LoadScene(sceneName);
    }
}
