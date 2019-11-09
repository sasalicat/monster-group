using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Text;
using System.IO;

public class xml_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var serializedData = (byte[])null;
        PlayerInf playerData = new PlayerInf();
        playerData.lv = 100;
        playerData.moneyLeft = 2;
        playerData.army = new List<RoleRecord>(){new RoleRecord(2)};
        playerData.itemInBag = new List<int>() { 1, 2, 5 };

        var serializer = new XmlSerializer(typeof(PlayerInf));
        using (var ms = new MemoryStream())
        {
            using (var sw = new StreamWriter(ms, Encoding.UTF8))
            {
                serializer.Serialize(sw, playerData);
                serializedData = ms.ToArray();
            }
        }
        PlayerInf newInf;
        // Deserialization
        using (var ms = new MemoryStream(serializedData))
        {
            using (var sr = new StreamReader(ms, Encoding.UTF8))
            {
                newInf = (PlayerInf)serializer.Deserialize(sr);
            }
        }
        newInf.printInf();
	}
}
