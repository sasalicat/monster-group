using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBelt : MonoBehaviour, Callback4Unit
{
    SkillBelt skillBelt;
    unitControler controler;
    BasicDelegate.withDamage aftCauseDamage;
    void aftCauseDamage_cb(Damage damage)
    {
        aftTakeDamage(damage);
    }
    public BasicDelegate.withDamage _AftCauseDamage
    {
        get
        {
            return aftCauseDamage;
        }

        set
        {
            aftCauseDamage = value;
        }
    }
    public void aftTakeDamage_cb(Damage damage)
    {
        aftTakeDamage(damage);
    }
    BasicDelegate.withDamage aftTakeDamage;
    public BasicDelegate.withDamage _AftTakeDamage
    {
        get
        {
            return aftTakeDamage;
        }

        set
        {
            aftTakeDamage += value;
        }
    }
    BasicDelegate.forSkillTrageting aftUseSkill;
    public void aftUseSkill_cb(SkillInf skillInf,Dictionary<string,object> skillArgs,unitControler[] tragets)
    {
        aftUseSkill(skillInf, skillArgs,tragets);
    }
    public BasicDelegate.forSkillTrageting _AftUseSkill
    {
        get
        {
            return aftUseSkill;
        }

        set
        {
            aftUseSkill = value;
        }
    }

    BasicDelegate.forSkill be_appoint;
    private void beAppoint_cb(SkillInf skillInf, Dictionary<string, object> skillArgs)
    {
        be_appoint(skillInf, skillArgs);
    }
    public BasicDelegate.forSkill _BeAppoint
    {
        get
        {
            return be_appoint;
        }

        set
        {
            be_appoint = value;
        }
    }
    BasicDelegate.withDamage befTakeDamage;
    void befTakeDamage_cb(Damage damage)
    {
        befTakeDamage(damage);
    }
    public BasicDelegate.withDamage _BefTakeDamage
    {
        get
        {
            return befTakeDamage;
        }

        set
        {
            befTakeDamage += value;
        }
    }
    void befUseSkill_cb(SkillInf skillInf, Dictionary<string, object> skillArgs, unitControler[] tragets)
    {
        befUseSkill(skillInf, skillArgs, tragets);
    }
    BasicDelegate.forSkillTrageting befUseSkill;
    public BasicDelegate.forSkillTrageting _BefUseSkill
    {
        get
        {
            return befUseSkill;
        }

        set
        {
            befUseSkill = value;
        }
    }

    BasicDelegate.withInt onHpChange;
    void onLifeChange_cb(int hp)
    {
        onHpChange(hp);
    }
    public BasicDelegate.withInt _onHpChange
    {
        get
        {
            return onHpChange;
        }

        set
        {
            onHpChange = value;
        }
    }
    public virtual void addItemBy(string represName)//這個方法是在遊戲開始時執行的,這個時候已經不可能更換裝備了,所以無視屬性更新,只加上裝備技能
    {
        object newrepres = System.Activator.CreateInstance(System.Type.GetType(represName));
        //((BasicControler)controler).data.attributeUpdate = ((item_representation)newrepres).Attributes;
        if (((item_representation)newrepres).ScriptName!=null)
        {
            skillBelt.addSkillBy(((item_representation)newrepres).ScriptName);
        }
    }
    public virtual void init(unitControler controler, List<int> itemNos)
    {
        this.controler = controler;
        skillBelt = GetComponent<SkillBelt>();
        ((BasicControler)controler)._beAppoint += beAppoint_cb;
        ((BasicControler)controler)._befUseSkill += befUseSkill_cb;
        ((BasicControler)controler)._aftUseSkill += aftUseSkill_cb;
        ((BasicControler)controler)._befTakeDamage += befTakeDamage_cb;
        ((BasicControler)controler)._aftTakeDamage += aftTakeDamage_cb;
        ((BasicControler)controler)._aftCauseDamage += aftCauseDamage_cb;
        ((BasicControler)controler).data._onLifeChange += onLifeChange_cb;
        foreach(int no in itemNos)
        {
            addItemBy(itemList.main.representation[no]);
        }
    }
}
