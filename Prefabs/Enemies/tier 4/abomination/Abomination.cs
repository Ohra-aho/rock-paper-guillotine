using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abomination : MonoBehaviour
{
    public void LoseAdapt()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<Weapon>().armor < 4) RIE.transform.GetChild(i).GetComponent<Weapon>().armor++;
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().damage > 0)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage--;
            }
        }
    }

    public void WinAdapt()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().damage < 4) RIE.transform.GetChild(i).GetComponent<Weapon>().damage++;
            if (RIE.transform.GetChild(i).GetComponent<Weapon>().armor > 0)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().armor--;
            }
        }
    }

    public void Unbeateble()
    {
        GetComponent<EffectDamage>().amount = 2 - GetComponent<Weapon>().armor;
        if(GetComponent<EffectDamage>().amount < 0)
        {
            GetComponent<EffectDamage>().amount = 0;
        }
        GetComponent<EffectDamage>().DealDamage(null);
    }

    public void Unkillable()
    {
        GetComponent<Healing>().amount = 2 - GetComponent<Weapon>().damage;
        if(GetComponent<Healing>().amount < 0)
        {
            GetComponent<Healing>().amount = 0;
        }
        GetComponent<Healing>().Heal();
    }

    public void Lost()
    {
        GameObject.Find("Abomination(Clone)").GetComponent<AbominationBehavior>().damaged = true;
    }
}
