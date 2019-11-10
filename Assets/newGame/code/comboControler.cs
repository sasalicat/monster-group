using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboControler : BasicControler{
    public BasicDelegate.forSkill _aftBeSkill;//basicControler沒有被使用技能后的時間,這裡作為補全


    public BasicDelegate.forSkill _aftDodge;
    public void dodgeAction(SkillInf skillInf, Dictionary<string, object> skillArgs){
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Dodge_Rate)//如果閃避成功
            ((Dictionary<comboControler, bool>)skillArgs["miss"])[this] = true;
            _aftDodge(skillInf, skillArgs);   
    }

    public virtual Dictionary<string,object> createSkillArg(unitData data,unitControler[] tragets)
    {
        Dictionary<string, object> arg = new Dictionary<string, object>();
        Dictionary<comboControler,bool> missDict = new Dictionary<comboControler,bool>();
        foreach(comboControler traget in tragets){
            missDict[traget] = false;
        }
        arg["user"] = this;
        arg["miss"] = missDict;
        arg["bonus"] = false;//因為技能效果所而額外觸發的技能
        arg["dice"] = Randomer.main.getInt();
        arg["critical"] = false;
        return arg;
    }
    public override void takeDamage(Damage damage)
    {
        Debug.Log("before _befTakeDamage");
        _befTakeDamage(damage);
        BasicControler from = (BasicControler)damage.creater;
        damage.creater = this;
        from._befCauseDamage(damage);
        damage.creater = from;

        Debug.Log("after _befTakeDamage");
        if (damage.vaild && !data.Dead)
        {

            int hurt = damage.num;
            if (damage.kind == Damage.KIND_PHYSICAL && !state.ImmunePhysics)
            {
                //Debug.Log("計算傷害時Physical_Reduce_Multiple為:" + data.Physical_Reduce_Multiple);
                hurt = (int)(data.Physical_Reduce_Multiple * (float)damage.num);
                //Debug.Log("計算傷害時hurt為:"+hurt);
                //Debug.Log("計算傷害時Now_Life為:" + data.Now_Life);

            }
            else if (damage.kind == Damage.KIND_MAGICAL && !state.ImmuneMagic)
            {
                hurt = (int)(data.Magic_Reduce_Multiple * damage.num);
            }
            data.Now_Life -= hurt;
            //Debug.Log("計算結束");
            damage.num = hurt;
            _aftTakeDamage(damage);
            createDamageNum(damage);

            damage.creater = this;//將creater改成自己來告訴傷害的造成者傷害目標是誰
            if (damage.creater != null)
            {
                from._aftCauseDamage(damage);
            }
        }

    }
    public override void useSkill(Skill skill, unitControler[] tragets, Dictionary<string, object> arg)
    {
        if (((BasicControler)skill.Owner) != this)
        {
            return;
        }
        arg["tragets"] = tragets;
        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, arg);//被指定
        }
        _befUseSkill(skill.information, arg, ref tragets);
        ((CDSkill)skill).trigger(arg);
        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget).__aftBeSkill(skill.information, arg);//技能結算后
        }
        _aftUseSkill(skill.information, arg, tragets);
    }
        public virtual void useSkill(Skill skill,unitControler[] tragets)
    {
        //Debug.Log("skill:" + skill.name);
        if(((BasicControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = createSkillArg(data);

        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        _befUseSkill(skill.information,skillArg,ref tragets);
        //Debug.LogWarning("在useSkill后tragets Count:"+tragets.Length);
        skillArg["tragets"] = tragets;
        ((CDSkill)skill).trigger(skillArg);
        foreach (unitControler traget in tragets)
        {
            ((BasicControler)traget)._aftBeSkill(skill.information, skillArg);
        }
        _aftUseSkill(skill.information, skillArg, tragets);
    }
}
