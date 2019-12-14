using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCreater : NumberCreater {
    public const int BATTER = 0;
    public const int BLOCK = 1;
    public const int COUNT = 2;
    public const int CRIT = 3;
    public const int DODGE = 4;
    public Sprite[] textPrefabs = new Sprite[5];
    public void createText(int code,Vector2 pos)
    {
        GameObject txt = Instantiate(missPrafeb, pos, Quaternion.EulerAngles(0, 0, 0));
        txt.GetComponent<SpriteRenderer>().sprite = textPrefabs[code];
    }
}
