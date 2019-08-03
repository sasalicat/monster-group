using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_fastfrost : CDSkill {

    protected virtual void ActionForTraget(unitControler traget)
    {

    }

    protected virtual int missileNo
    {
        get
        {
            return 30;
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
            return owner.data.Now_Attack_Interval * 4.5f;
        }
    }

    public override unitControler[] findTraget(Environment env)
    {
        unitControler[] tragets = new unitControler[1];
        tragets[0] = owner.traget;
        return tragets;
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
                bool haveBuff = (((BasicControler)traget).GetComponent<buff_chill>() != null);//如果目標有寒冷狀態,則暴擊
                ActionForTraget(traget);
                //Debug.Log("冷卻時間:" + CoolDown);
                //Debug.Log("自身位置:" + transform.position + "相對位置:" + transform.TransformDirection(offset));

                GameObject mislobj = Instantiate(objectList.main.prafebList[missileNo], ((BasicControler)traget).transform.position, transform.rotation,((BasicControler)traget).transform);
                GameObject effobj = Instantiate(objectList.main.prafebList[effNo_hit], ((BasicControler)traget).gameObject.transform);
                effobj.transform.localPosition = Vector2.zero;
                float multip = (float)args["control_multiple"];
                float time = 1.5f*unitData.STAND_ATK_INTERVAL * multip;
                if (haveBuff) {
                    time *= 2;
                }
                Dictionary<string, object> buffArg = new Dictionary<string, object>();
                buffArg["time"] = time;
                traget.addBuff("buff_stun", buffArg);
            }

        }
        else
        {
            BasicControler traget = (BasicControler)tragets[0];
            NumberCreater.main.CreateMissing(traget.transform.position);
        }
        setTime();
    }
}
