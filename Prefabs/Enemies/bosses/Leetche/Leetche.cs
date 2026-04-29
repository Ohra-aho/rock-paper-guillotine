using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leetche : MonoBehaviour
{
    public void SuckerDraw()
    {
        GetComponent<PermanentDebuffer>().DecreaseOpposingHealth(1);
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void SuckerLoss()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Weapon>().opponent.player_owner.HB.DecreaseHealthBar(1, true);
            GetComponent<Stacking>().DecreaseStacks(1);
        }
    }

    //Pincer
    public void PincerDraw()
    {
        if(GetComponent<Weapon>().GiveEffectiveDamage() > 0)
        {
            GetComponent<PermanentDebuffer>().DebuffOpposingWeaponDamage(1);
            GetComponent<Stacking>().IncreaseStacks(1);
        }
    }

    public void PincerLoss()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        if(GetComponent<Stacking>().stacks > 0)
        {
            for (int i = 0; i < RI.transform.childCount; i++)
            {
                if (RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_debuff") != null)
                {
                    GameObject buff = RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_debuff");
                    buff.GetComponent<Buff>().RemoveBuff();
                    Destroy(buff);
                    GetComponent<Stacking>().DecreaseStacks(1);
                    break;
                }
            }
        }
    }

    //Gaze
    public void GazeDraw()
    {
        if(GetComponent<Weapon>().opponent.type != MainController.Choise.hyödytön)
        {
            GetComponent<PermanentDebuffer>().MakeOpposingWeaponUseless();
            GetComponent<Stacking>().IncreaseStacks(1);
        }
    }

    public void GazeLoss()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GameObject RI = GameObject.FindGameObjectWithTag("RI");

            for (int i = 0; i < RI.transform.childCount; i++)
            {
                if (RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_debuff") != null)
                {
                    GameObject buff = RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_debuff");
                    buff.GetComponent<Buff>().RemoveBuff();
                    Destroy(buff);
                    GetComponent<Stacking>().DecreaseStacks(1);
                }
            }
        }
    }

    //Ciphen
    public void CiphenWin() 
    {
        int stacks = 0;
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Stacking>())
            {
                stacks += RIE.transform.GetChild(i).GetComponent<Stacking>().stacks;
                RIE.transform.GetChild(i).GetComponent<Stacking>().DecreaseStacks(RIE.transform.GetChild(i).GetComponent<Stacking>().stacks);
            }
        }
        if(stacks > 0)
        {
            GetComponent<Healing>().amount = stacks;
            GetComponent<Healing>().Heal();
            GetComponent<Healing>().amount = 0;
        }
    }

    public void CiphenLoss()
    {
        GetComponent<EffectDamage>().SelfDamage(null);
    }

    //Rushdown
    private void Awake()
    {
        if(GetComponent<BuffController>())
        {
            GetComponent<BuffController>().special_apply = true;
            GetComponent<BuffController>().buff_requirement = (Weapon w) => { return GetComponent<Weapon>().name != w.name; };
            GetComponent<BuffController>().lose = true;
            GetComponent<BuffController>().special = (Weapon w) => { if(w.draw != null) w.draw.Invoke(); };
            GetComponent<BuffController>().timer = 2;
            GetComponent<BuffController>().temporary = true;
        }
    }
}
