using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_hack :skill_BaseAttack {

    public override bool canUse
    {
        get
        {
            return timeLeft <= 0;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return 1 * unitData.STAND_ATK_INTERVAL;
        }
    }
    public override int effNo
    {
        get
        {
            return 4;
        }
    }
    protected override Damage createDamage(Dictionary<string, object> skillArg)
    {
        return new Damage((int)(owner.data.Now_Attack*0.8f*(float)skillArg["phy_damage_multiple"])+(int)skillArg["phy_damage_addition"],Damage.KIND_PHYSICAL,owner);
    }
    public override unitControler[] findTraget(Environment env)
    {
        Debug.Log("owner:"+owner.gameObject.name+ "在順斬劈的findTraget owner.traget為:" + owner.traget);
        if (owner.traget != null)
        {
            ChessBoard board = (ChessBoard)env;
            int[] traget_pos = board.getPosFor(owner.traget);
            //Debug.Log("目標位置 大小:" + traget_pos.Length+" x:"+traget_pos[0]+);
            List<BasicControler> tragets = new List<BasicControler>();
            tragets.Add((BasicControler)owner.traget);
            if (traget_pos[0] - 1 >= 0) {
                if (board.board[traget_pos[1], traget_pos[0]-1] != null)
                    tragets.Add((BasicControler)board.board[traget_pos[1], traget_pos[0]-1]);
            }
            if (traget_pos[0] + 1< board.X)
            {
                if (board.board[traget_pos[1], traget_pos[0]+1] != null)
                    tragets.Add((BasicControler)board.board[traget_pos[1], traget_pos[0]+1]);
            }
            return tragets.ToArray();
        }
        return null;
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        Debug.Log("順斬劈初始化!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        this.owner = (BasicControler)owner;
        information = new SkillInf(false,true,false,false,new List<string>() {SkillInf.TAG_DAMAGE});
        oriPos = transform.position;
        effection = GetComponent<sp_effection>();
    }
    /*public override void trigger(Dictionary<string, object> args)
    {
        //Debug.Log("攻擊被觸發");
        //BasicControler traget = (BasicControler)args["tragets"];
        //Debug.Log("traget:"+traget);
        //Debug.Log("traget type:" + (args["tragets"].GetType()));
        if (!(bool)args["miss"])
        {
            unitControler[] tragets = (unitControler[])args["tragets"];
            //Debug.Log("製造傷害時傷害數值為:" + damage.num);
            Debug.Log("順斬劈被觸發 tragets Length:" + tragets.Length);
            foreach(unitControler traget in tragets)
            {
                traget.takeDamage(createDamage(args));
            }
            anim_time = 0;
            stay_time = 0;
            nowTraget = ((BasicControler)tragets[0]).gameObject;
            count = 0;
            //triggerEff = false;
            //Timer.main.logInTimer(Anim);
        //}
        setTime();
    }*/
    public override void actionTo(unitControler[] tragets, Dictionary<string, object> skillArg)
    {
        foreach (unitControler traget in tragets)
        {
            traget.takeDamage(createDamage(skillArg));
        }
    }
    //public override 

}
