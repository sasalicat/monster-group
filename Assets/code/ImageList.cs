using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageList : MonoBehaviour {
    public static ImageList main = null;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public List<Sprite> headIcons;
    public List<Sprite> skillIcons;
}
