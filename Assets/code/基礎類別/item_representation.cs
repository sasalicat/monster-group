using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface item_representation  {

    string itemName
    {
        get;
    }
    string Explanation
    {
        get;
    }
    string Commentary
    {
        get;
    }

    string ScriptName//可以回傳null,如果回傳了腳本名,這個腳本必須是技能類別
    {
        get;
    }
    int Price
    {
        get;
    }
    Dictionary<byte, int> Attributes {//唯一和skill_represention不一樣的地方,以為裝備絕大多數都會加屬性所以統一用一個字典儲存
        get;
    }
}
