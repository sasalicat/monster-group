using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_polarWind : CDSkill
{
    protected virtual Damage createDamage(Dictionary<string, object> skillArg)
    {
        int num = 6;
        List<string> tag = new List<string>() { Damage.TAG_ICE, Damage.TAG_REMOTE };

        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    protected virtual void ActionForTraget(unitControler traget)
    {

    }
    protected virtual Vector2 offset
    {
        get
        {
            return new Vector2(1,-0.25f);
        }
    }
    protected virtual int missileNo
    {
        get
        {
            return 29;
        }
    }
    protected virtual int effNo_hit
    {
        get
        {
            return 25;
        }
    }
    public override bool canUse
    {
        get
        {
            return timeLeft <= 0 && owner.traget != null && owner.state.CanSkill;
        }
    }

    public override float StandCoolDown
    {
        get
        {
            return owner.data.Now_Attack_Interval * 3;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        List<unitControler> list = new List<unitControler>();
        list.Add(owner.traget);
        ChessBoard board = (ChessBoard)env;
        int[] pos = board.getPosFor(owner.traget);
        if (pos[0]-1 >= 0 && board.board[pos[1], pos[0]-1] != null)
        {
            list.Add(board.board[pos[1], pos[0]-1]);
        }
        if (pos[0]+1<board.X && board.board[pos[1], pos[0]+1] != null)
        {
            list.Add(board.board[pos[1], pos[0]+1]);
        }
        return list.ToArray();
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(true, true, false, new List<string>() { SkillInf.TAG_DAMAGE });

    }
    public override void trigger(Dictionary<string, object> args)
    {
        //Debug.Log("攻擊被觸發");
        unitControler[] tragets = (unitControler[])args["tragets"];
        if (!(bool)args["miss"])
        {
            //BasicControler traget = (BasicControler)args["tragets"];
            //Debug.Log("traget:"+traget);
            //Debug.Log("traget type:" + (args["tragets"].GetType()));
            foreach (unitControler traget in tragets)
            {

                BasicControler nowTraget = (BasicControler)traget;

                //Debug.Log("製造傷害時傷害數值為:" + damage.num);
                Debug.Log("traget 為:" + ((BasicControler)traget).gameObject.name);
               
                traget.takeDamage(createDamage(args));
                ActionForTraget(traget);
                Dictionary<string, object> buffArg = new Dictionary<string, object>();
                buffArg["time"] = 3f;
                buffArg["layer"] = 1;
                buffArg["creater"] = owner;
                nowTraget.addBuff("buff_chill", buffArg);
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));

                GameObject effobj = Instantiate(objectList.main.prafebList[effNo_hit], nowTraget.gameObject.transform);
                effobj.transform.localPosition = Vector2.zero;
            }
            GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo], ((BasicControler)tragets[0]).transform.position+(Vector3)offset, transform.rotation);
           
            
        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime();
    }
}
