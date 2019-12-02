using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboControler : BasicControler{
    public const int PLAYER_ROLE_NO= 0;
    public const int ENEMY_ROLE_NO = 1;
    public enum bonus_kind {NoBonus,Batter,Counter};
    public BasicDelegate.forSkill _aftBeSkill;//basicControler沒有被使用技能后的時間,這裡作為補全


    
    public override void init(AI ai, Environment env, unitData data, HpBar hpbar)
    {
        this._beAppoint += dodgeAction;
        this._aftBeSkill += counterAction;
        this._aftUseSkill += batterAction;
        this._befTakeDamage += blockAction;
        this._befCauseDamage += critAction;
        base.init(ai, env, data, hpbar);
    }

    public BasicDelegate.forSkill _aftDodge;
    public void dodgeAction(SkillInf skillInf, Dictionary<string, object> skillArgs){
        float denyRate = (float)skillArgs["dodgeDeny"];
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Dodge_Rate-denyRate)//如果閃避成功
            ((Dictionary<comboControler, bool>)skillArgs["miss"])[this] = true;
            _aftDodge(skillInf, skillArgs);   
    }
    public Skill counterSkill = null;
    public void counterAction(SkillInf skillInf, Dictionary<string, object> skillArgs)
    {
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Counter_Rate)
        {
            unitControler[] traget = new unitControler[]{(unitControler)skillArgs["user"]};
            Dictionary<string,object> args= createSkillArg(data);
            args["bonus"] = bonus_kind.Counter;
            useSkill(counterSkill, traget, args);
        }
    }
    public void batterAction(SkillInf skillInf, Dictionary<string, object> skillArgs,unitControler[] tragets)
    {
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Batter_Rate)
        {
            Dictionary<string, object> args = createSkillArg(data);
            args["bonus"] = bonus_kind.Batter;
            bool canBatter = false;
            if (!args.ContainsKey("batterTime"))
            {
                args["batterTime"] = 1;
                canBatter = true;
            }
            else
            {
                if ((int)args["batterTime"] < ((unitData_v2)data).Now_Batter_Limmit) {
                    args["batterTime"] = (int)args["batterTime"]+1;
                    canBatter = true;
                 }
            }
            if(canBatter)
                useSkill(((SkillInf_v2)skillInf).skill, tragets, args);
        }
    }
    public BasicDelegate.withDamage _aftBlock;
    public void blockAction(Damage damage)
    {
        float denyRate = (float)((Damage_v2)damage).extraArgs["blockDeny"];
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Batter_Rate - denyRate)
        {
            damage.num -= ((unitData_v2)data).Now_Block_Point;
            if (damage.num < 0)
            {
                damage.num = 0;
            }
            _aftBlock(damage);
        }
    }
    public BasicDelegate.withDamage _aftCrit;
    public void critAction(Damage damage)
    {
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Crit_Rate)
        {
            damage.num = (int)((unitData_v2)data).Now_Crit_Rate*damage.num;
            _aftCrit(damage);
        }
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
        arg["bonus"] = bonus_kind.NoBonus;//因為技能效果所而額外觸發的技能
        arg["dice"] = Randomer.main.getInt();
        arg["critical"] = false;
        arg["dodgeDeny"] = ((unitData_v2)data).Now_Insight_Rate * ((unitData_v2)data).Now_Insight_Reduce;
        arg["blockDeny"] = ((unitData_v2)data).Now_Insight_Rate * ((unitData_v2)data).Now_Insight_Reduce;
        return arg;
    }
    public override void takeDamage(Damage damage)
    {
        Debug.Log("before _befTakeDamage");
        _befTakeDamage(damage);
        comboControler from = (comboControler)damage.creater;
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
    public override void heal(int num, unitControler creater)
    {
        HealMsg msg = new HealMsg(num, creater);
        if (_befHealing != null)
        {
            _befHealing(msg);
        }
        data.Now_Life += num;
        closeupStage.main.display_number(this, msg.num, NumberCreater.GREEN);
        if (_aftHealing != null)
        {
            _aftHealing(msg);
        }
    }
    public override void useSkill(Skill skill, unitControler[] tragets, Dictionary<string, object> arg)
    {
        if (((comboControler)skill.Owner) != this)
        {
            return;
        }
        arg["tragets"] = tragets;
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._beAppoint(skill.information, arg);//被指定
        }
        _befUseSkill(skill.information, arg, ref tragets);
        ((CDSkill)skill).trigger(arg);
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._aftBeSkill(skill.information, arg);//技能結算后
        }
        _aftUseSkill(skill.information, arg, tragets);
    }
        public override void useSkill(Skill skill,unitControler[] tragets)
    {
        //Debug.Log("skill:" + skill.name);
        if(((comboControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = createSkillArg(data);

        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        _befUseSkill(skill.information,skillArg,ref tragets);
        //Debug.LogWarning("在useSkill后tragets Count:"+tragets.Length);
        skillArg["tragets"] = tragets;
        ((CDSkill)skill).trigger(skillArg);
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._aftBeSkill(skill.information, skillArg);
        }
        _aftUseSkill(skill.information, skillArg, tragets);
    }
}
