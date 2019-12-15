using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboControler : BasicControler{
    public const int PLAYER_ROLE_NO= 0;
    public const int ENEMY_ROLE_NO = 1;
    public enum bonus_kind {NoBonus,Batter,Counter};
    public BasicDelegate.forSkill _aftBeSkill;//basicControler沒有被使用技能后的時間,這裡作為補全
    public override void action(float time)
    {
        if (data.Dead)
        {
            return;
        }
        //Debug.Log("角色 action");
        //ai更新
        ai.update(this, env);
        //技能使用
        skillBelt.updateSkill(time, env);


        //處理buff
        foreach (Buff buff in buffList)
        {
            if (!failed.Contains(buff))
            {
                buff.onIntarvel(this, time);
            }
        }
        for (int i = 0; i < failed.Count; i++)
        {
            buffList.Remove(failed[i]);
        }
        failed.Clear();
    }

    public virtual void init(AI ai, Environment env, unitData data)
    {
        this._beAppoint += dodgeAction;
        this._aftBeSkill += counterAction;
        this._aftUseSkill += batterAction;
        this._befTakeDamage += blockAction;
        this._befCauseDamage += critAction;
        this.ai = ai;
        this.env = env;
        this.data = data;
        this.state =new unitState();
        this.data._onDeath = onUnitDeath;
        //base.init(ai, env, data, hpbar);
    }

    public BasicDelegate.forSkill _aftDodge;
    public void dodgeAction(SkillInf skillInf, Dictionary<string, object> skillArgs){
        float denyRate = (float)skillArgs["dodgeDeny"];
        if (Randomer.main.getInt() < 100 * (((unitData_v2)data).Now_Dodge_Rate - denyRate))
        { //如果閃避成功
            //Debug.LogWarning(gameObject.name + "閃避成功");
            ((Dictionary<comboControler, bool>)skillArgs["miss"])[this] = true;
            closeupStage.main.display_anim(this,roleAnim.DODGE);
            closeupStage.main.display_floatingText(this, TextCreater.DODGE);
        }
            if(_aftDodge!=null)
                _aftDodge(skillInf, skillArgs);   
    }
    public Skill counterSkill = null;
    public void counterAction(SkillInf skillInf, Dictionary<string, object> skillArgs)
    {

        bonus_kind kind = (bonus_kind)skillArgs["bonus"];
        if (kind != bonus_kind.Counter)
        {
            if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Counter_Rate)
            {
                //Debug.LogWarning(gameObject.name+"反擊");
                //Debug.LogWarning(gameObject.name + "反擊->" + ((comboControler)skillArgs["user"]).gameObject.name);
                unitControler[] traget = new unitControler[] { (unitControler)skillArgs["user"] };
                //Skill skill = (Skill)skillArgs["skill"];
                Dictionary<string, object> args = createSkillArg(data, traget);
                args["bonus"] = bonus_kind.Counter;
                //closeupStage.main.display_floatingText(this,TextCreater.COUNT);
                useSkill(counterSkill, traget, args);
            }
        }
    }
    public void batterAction(SkillInf skillInf, Dictionary<string, object> skillArgs,unitControler[] tragets)
    {
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Batter_Rate&& ((bonus_kind)skillArgs["bonus"])!=bonus_kind.Counter)//反擊不能觸發連擊
        {
            
            Dictionary<string, object> args = createSkillArg(data,tragets);
            args["bonus"] = bonus_kind.Batter;
            //args["skill"] = ((SkillInf_v2)skillInf).skill;
            bool canBatter = false;
            if (!skillArgs.ContainsKey("batterTime"))
            {
                args["batterTime"] = 1;
                canBatter = true;
            }
            else
            {
                if ((int)skillArgs["batterTime"] < ((unitData_v2)data).Now_Batter_Limmit) {
                    args["batterTime"] = (int)skillArgs["batterTime"]+1;
                    canBatter = true;
                 }
            }
            if (canBatter)
            {
                //Debug.LogWarning(gameObject.name + "連擊 次數"+ args["batterTime"]);
                //Debug.LogWarning(gameObject.name + "連擊 次數"+ args["batterTime"] + ">>>" + ((comboControler)tragets[0]).gameObject.name);
                //closeupStage.main.display_floatingText(this, TextCreater.BATTER);
                useSkill(((SkillInf_v2)skillInf).skill, tragets, args);
            }
        }
    }
    public BasicDelegate.withDamage _aftBlock;
    public void blockAction(Damage damage)
    {
        float denyRate = (float)((Damage_v2)damage).extraArgs["blockDeny"];
        if (Randomer.main.getInt() < 100 * (((unitData_v2)data).Now_Block_Rate - denyRate))
        {
            Debug.LogWarning(gameObject.name + "格擋");
            closeupStage.main.display_floatingText(this,TextCreater.BLOCK);
            damage.num -= ((unitData_v2)data).Now_Block_Reduce_Num;
            if (damage.num < 0)
            {
                damage.num = 0;
            }
            if (_aftBlock != null)
                _aftBlock(damage);
        }
    }
    public BasicDelegate.withDamage _aftCrit;
    public void critAction(Damage damage)
    {
        if (Randomer.main.getInt() < 100 * ((unitData_v2)data).Now_Crit_Rate)
        {
           
            damage.num = (int)(((unitData_v2)data).Now_Crit_Magnif*damage.num);
            closeupStage.main.display_floatingText(this,TextCreater.CRIT);
            //(Dictionary<comboControler, bool>)((Damage_v2)damage).extraArgs["critical"])[]
            ((Damage_v2)damage).extraArgs["critical"] = true;
            //Debug.LogWarning("致命一擊修改傷害為:"+damage.num);
            if (_aftCrit!=null)
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
        Dictionary<comboControler, bool> critDict = new Dictionary<comboControler, bool>();
        foreach(comboControler traget in tragets)
        {
            critDict[traget] = false;
        }
        arg["user"] = this;
        arg["miss"] = missDict;
        arg["bonus"] = bonus_kind.NoBonus;//因為技能效果所而額外觸發的技能
        arg["dice"] = Randomer.main.getInt();
        arg["critical"] = critDict;
        arg["dodgeDeny"] = ((unitData_v2)data).Now_Insight_Rate * ((unitData_v2)data).Now_Insight_Reduce;
        arg["blockDeny"] = ((unitData_v2)data).Now_Insight_Rate * ((unitData_v2)data).Now_Insight_Reduce;
        arg["tragets"] = tragets;
        arg["cooldown_multiple"] = 1f;
        arg["phy_damage_multiple"] = 1f;
        arg["phy_damage_addition"] = 0;
        arg["mag_damage_multiple"] = 1f;
        arg["mag_damage_addition"] = 0;
        arg["healing_multiple"] = 1f;
        arg["healing_addition"] = 0;
        return arg;
    }
    public override void takeDamage(Damage damage)
    {
        //Debug.Log("before _befTakeDamage");
        //Debug.LogWarning(">初始傷害"+damage.num);
        _befTakeDamage(damage);
        comboControler from = (comboControler)damage.creater;
        damage.creater = this;
        //Debug.LogWarning(">_befTakeDamage后傷害" + damage.num);
        from._befCauseDamage(damage);
        damage.creater = from;
        //Debug.LogWarning(">_befCauseDamage后傷害" + damage.num);
        //Debug.Log("after _befTakeDamage");
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
            //Debug.LogWarning(">真實減少生命值:" + hurt);
            data.Now_Life -= hurt;
            //Debug.Log("計算結束");
            damage.num = hurt;
            _aftTakeDamage(damage);
            if ((bool)((Damage_v2)damage).extraArgs["critical"])
            {
                closeupStage.main.display_number(this,damage.num,1);
            }
            else
            {
                closeupStage.main.display_number(this, damage.num, 0);
            }
            //createDamageNum(damage);

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
        if (data.Dead)
        {
            return;
        }
        if (tragets.Length == 0) {
            Debug.Log("使用技能"+skill.name+"沒有任何目標");
            return;
        }
        if (((comboControler)skill.Owner) != this)
        {
            return;
        }
        arg["tragets"] = tragets;
        arg["skill"] = skill;
        bool trigger = (bonus_kind)arg["bonus"] != bonus_kind.NoBonus;
        closeupStage.main.display_skill(this,skill,new List<unitControler>(tragets),trigger);
        closeupStage.main.display_showSkillIcon(this, (dynamicSkill)skill);
        if ((bonus_kind)arg["bonus"] == bonus_kind.Counter)
        {
            closeupStage.main.display_floatingText(this,TextCreater.COUNT);
        }
        else if((bonus_kind)arg["bonus"] == bonus_kind.Batter)
        {
            closeupStage.main.display_floatingText(this, TextCreater.BATTER);
        }
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._beAppoint(skill.information, arg);//被指定
        }
        _befUseSkill(skill.information, arg, ref tragets);
        ((CDSkill)skill).trigger(arg);
        foreach (unitControler traget in tragets)
        {//最後GG在這裡
            ((comboControler)traget)._aftBeSkill(skill.information, arg);//技能結算后
        }
        _aftUseSkill(skill.information, arg, tragets);
        closeupStage.main.display_skillEnd();
    }
    public override void useSkill(Skill skill,unitControler[] tragets)
    {
        if (data.Dead)
        {
            return;
        }
        //Debug.LogWarning(gameObject.name + "基本行動");
        if (tragets.Length == 0)
        {
            //Debug.Log("使用技能" + skill.name + "沒有任何目標");
            return;
        }
        //Debug.Log("skill:" + skill.name);
        if (((comboControler)skill.Owner) != this)
        {
            return;
        }
        Dictionary<string, object> skillArg = createSkillArg(data,tragets);
        skillArg["skill"] = skill;
        bool trigger = (bonus_kind)skillArg["bonus"] != bonus_kind.NoBonus;
        closeupStage.main.display_skill(this, skill, new List<unitControler>(tragets), trigger);
        closeupStage.main.display_showSkillIcon(this, (dynamicSkill)skill);
        _befUseSkill(skill.information, skillArg, ref tragets);
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._beAppoint(skill.information, skillArg);//被指定
        }
        
        //Debug.LogWarning("在useSkill后tragets Count:"+tragets.Length);
        //skillArg["tragets"] = tragets;
        ((CDSkill)skill).trigger(skillArg);
        foreach (unitControler traget in tragets)
        {
            ((comboControler)traget)._aftBeSkill(skill.information, skillArg);
        }
        _aftUseSkill(skill.information, skillArg, tragets);
        closeupStage.main.display_skillEnd();
        //Debug.LogWarning(gameObject.name + "基本行動結束");
    }
}
