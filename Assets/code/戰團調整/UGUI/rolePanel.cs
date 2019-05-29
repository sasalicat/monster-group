using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rolePanel : MonoBehaviour
{
    public Image headIcon;
    public Text[] Attributes;
    public string[] Prefix;
    public Text name;
    public Text career;
    public enum attribute {atk,max_hp,atk_accelerate,atk_interval,magic,mg_damage_reinforce,cd_reinforce,cd_time_reduce,armor,phy_damage_reduce,resistance,mg_damage_reduce}
    public void updateAttr(attribute attr,string context)
    {
        Attributes[(int)attr].text = Prefix[(int)attr] + context;
    }
    public void init(RoleRecord role)
    {
        headIcon.sprite = ImageList.main.headIcons[role.race];
        updateAttr(attribute.atk, "" + role.data.Now_Attack);
        updateAttr(attribute.max_hp, "" + role.data.Now_Max_Life);
        updateAttr(attribute.atk_accelerate, "" + role.data.Now_Attack_Speed);
        updateAttr(attribute.atk_interval, "" + role.data.Now_Attack_Interval);
        updateAttr(attribute.magic, "" + role.data.Now_Mag_Reinforce);
        updateAttr(attribute.mg_damage_reinforce, "" + role.data.Now_Mag_Multiple);
        updateAttr(attribute.cd_reinforce, "" + role.data.Now_Cooldown_Reinforce);
        updateAttr(attribute.cd_time_reduce, "" + role.data.Now_Cooldown_Mutiple);
        updateAttr(attribute.armor, "" + role.data.Now_Armor);
        updateAttr(attribute.phy_damage_reduce, "" + role.data.Physical_Reduce_Multiple);
        updateAttr(attribute.resistance, "" + role.data.Now_Mag_Resistance);
        updateAttr(attribute.mg_damage_reduce, "" + role.data.Magic_Reduce_Multiple);

    }
}
