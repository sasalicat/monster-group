using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_fireRain : CDSkill
{
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
            return 6 * unitData.STAND_ATK_INTERVAL;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        int[] pos= ((ChessBoard)env).getPosFor(owner.traget);
        List<unitControler> list = new List<unitControler>();
        for(int y = 0; y < 3; y++)
        {
            for(int x =0; x < 3; x++)
            {
                if(pos[1]-1+y< ((ChessBoard)env).Y&& pos[1] - 1 + y >=0&&pos[0]-1+x < ((ChessBoard)env).X&& pos[0] - 1 + x>=0)
                {
                    BasicControler unit = (BasicControler)((ChessBoard)env).board[pos[1] - 1 + y, pos[0] - 1 + x];
                    if (unit != null&&unit.playerNo!=owner.playerNo)
                    {
                        list.Add(unit);
                    }

                }
            }
        }
        return list.ToArray();
    }

    public override void onInit(unitControler owner, Callback4Unit deleg)
    {
        this.owner = (BasicControler)owner;
        this.information = new SkillInf(false, true, false, new List<string>() { SkillInf.TAG_DAMAGE,SkillInf.TAG_FIRE});
    }
    public virtual void misslieHit(missile m)
    {
        Debug.Log("missile Hit被觸發");
        GameObject effobj = Instantiate(objectList.main.prafebList[13], m.traget.gameObject.transform);
        effobj.transform.localPosition = Vector2.zero;
        Debug.Log("物件名稱:" + effobj.gameObject.name);
    }
    protected virtual Damage createDamage(Dictionary<string, object> skillArg)
    {
        int num = 6;
        List<string> tag = new List<string>() { Damage.TAG_FIRE, Damage.TAG_REMOTE };
        if ((bool)skillArg["critical"])
        {
            tag.Add("critical");
        }
        Damage damage = new Damage((int)(num * (float)skillArg[Skill.ARG_MAG_MUL] + (int)skillArg[Skill.ARG_MAG_ADD]), Damage.KIND_MAGICAL, owner, tag);

        return damage;
    }
    public override void trigger(Dictionary<string, object> args)
    {
        Vector2 stoneOffset = new Vector2(2, 2);
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
                Debug.Log("火焰雨 traget 為:" + ((BasicControler)traget).gameObject.name);
                traget.takeDamage(createDamage(args));
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));
    

                GameObject mislobj = Instantiate(objectList.main.prafebList[14], (Vector2)((BasicControler)traget).transform.position+stoneOffset, transform.rotation);
                mislobj.GetComponent<missile>().traget = ((BasicControler)traget).gameObject;

                mislobj.GetComponent<missile>().on_missile_hited += misslieHit;
            }

        }
        else
        {
            foreach(BasicControler traget in tragets)
                NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime(args);
    }
}

