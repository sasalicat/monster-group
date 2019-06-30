using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rolePanel : MonoBehaviour
{
    public RoleRecord nowRole;
    public Image headIcon;
    public Text[] Attributes;
    public string[] Prefix;
    public Text name;
    public Text career;
    public skillBar skillBar;
    public equipBar equipBar;

    public enum attribute {atk,max_hp,atk_accelerate,atk_interval,magic,mg_damage_reinforce,cd_reinforce,cd_time_reduce,armor,phy_damage_reduce,resistance,mg_damage_reduce}
    protected void updateAttr(attribute attr,string context)
    {
        Attributes[(int)attr].text = Prefix[(int)attr] + context;
    }
    public void init(RoleRecord role)
    {
        nowRole = role;
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
        skillBar.init(role);
        equipBar.init(role);
    }
    public void Awake()
    {
        dataWarehouse.main.updateNowRoleAttr += updateUnitAttr;
        dataWarehouse.main.denyNowRoleAttr += denyUnitAttr;
    }
    public void updateUnitAttr(Dictionary<byte, int> attr)
    {
        nowRole.data.attributeUpdate =attr;
        updateAttr(attribute.atk, "" + nowRole.data.Now_Attack);
        updateAttr(attribute.max_hp, "" + nowRole.data.Now_Max_Life);
        updateAttr(attribute.atk_accelerate, "" + nowRole.data.Now_Attack_Speed);
        updateAttr(attribute.atk_interval, "" + nowRole.data.Now_Attack_Interval);
        updateAttr(attribute.magic, "" + nowRole.data.Now_Mag_Reinforce);
        Debug.Log("nowdata 智力:" + nowRole.data.Now_Mag_Reinforce+"nowData 技能加強:"+nowRole.data.Now_Mag_Multiple);
        updateAttr(attribute.mg_damage_reinforce, "" + nowRole.data.Now_Mag_Multiple);
        updateAttr(attribute.cd_reinforce, "" + nowRole.data.Now_Cooldown_Reinforce);
        updateAttr(attribute.cd_time_reduce, "" + nowRole.data.Now_Cooldown_Mutiple);
        updateAttr(attribute.armor, "" + nowRole.data.Now_Armor);
        updateAttr(attribute.phy_damage_reduce, "" + nowRole.data.Physical_Reduce_Multiple);
        updateAttr(attribute.resistance, "" + nowRole.data.Now_Mag_Resistance);
        updateAttr(attribute.mg_damage_reduce, "" + nowRole.data.Magic_Reduce_Multiple);
    }
    public void denyUnitAttr(Dictionary<byte, int> attr)
    {
        nowRole.data.attributeDeny = attr;
        updateAttr(attribute.atk, "" + nowRole.data.Now_Attack);
        updateAttr(attribute.max_hp, "" + nowRole.data.Now_Max_Life);
        updateAttr(attribute.atk_accelerate, "" + nowRole.data.Now_Attack_Speed);
        updateAttr(attribute.atk_interval, "" + nowRole.data.Now_Attack_Interval);
        updateAttr(attribute.magic, "" + nowRole.data.Now_Mag_Reinforce);
        updateAttr(attribute.mg_damage_reinforce, "" + nowRole.data.Now_Mag_Multiple);
        updateAttr(attribute.cd_reinforce, "" + nowRole.data.Now_Cooldown_Reinforce);
        updateAttr(attribute.cd_time_reduce, "" + nowRole.data.Now_Cooldown_Mutiple);
        updateAttr(attribute.armor, "" + nowRole.data.Now_Armor);
        updateAttr(attribute.phy_damage_reduce, "" + nowRole.data.Physical_Reduce_Multiple);
        updateAttr(attribute.resistance, "" + nowRole.data.Now_Mag_Resistance);
        updateAttr(attribute.mg_damage_reduce, "" + nowRole.data.Magic_Reduce_Multiple);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("點擊");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //摄像机需要设置MainCamera的Tag这里才能找到
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
                //Debug.Log("caster.cast() 結果:" + caster.cast());
                if (castItem.main.cast() != null)
                {
                    //因為點裝備欄的時候也不希望把裝備面板關掉,
                    //關掉就不能拖進裝備欄了
                }
                else if (hit.collider)
                {
                    //Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
                    Debug.Log("hitted:" + hit.transform.name + "tag:" + hit.transform.tag);
                    if (hit.transform.tag != "RoleUI")
                    {
                        Debug.Log("沒點擊到roleUI");
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("沒點擊到roleUI");
                    gameObject.SetActive(false);
                }

            }

        }
        
    }
}
