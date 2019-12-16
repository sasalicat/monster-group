using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  animKeyDict {
    Dictionary<int, string> dict;
    protected abstract Dictionary<int, string> createDict();
    public  string this[int code]//輸入是roleAnim的code輸出的是動畫Parameters name
    {
        get
        {
            return dict[code];
        }
    }
    public animKeyDict()
    {
        dict = createDict();
    }
}
