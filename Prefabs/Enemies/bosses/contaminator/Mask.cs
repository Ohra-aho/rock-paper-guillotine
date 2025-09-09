using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public bool self_damage_nullified = false; 
    public void NullifyContaminator()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder").transform.GetChild(0).gameObject;
        enemy.GetComponent<Contaminator>().mask_active = true;

        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<EffectDamage>())
            {
                if(RIE.GetChild(i).GetComponent<GasGranade>())
                {
                    RIE.GetChild(i).GetComponent<GasGranade>().self_damage_nullified = true;
                } 
                else if(RIE.GetChild(i).GetComponent<Mask>())
                {
                    RIE.GetChild(i).GetComponent<Mask>().self_damage_nullified = true;
                }
            }
        }
    }

    public void ResetContaminator()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder").transform.GetChild(0).gameObject;
        enemy.GetComponent<Contaminator>().mask_active = false;

        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<EffectDamage>())
            {
                if (RIE.GetChild(i).GetComponent<GasGranade>())
                {
                    RIE.GetChild(i).GetComponent<GasGranade>().self_damage_nullified = false;
                }
                else if(RIE.GetChild(i).GetComponent<Mask>())
                {
                    RIE.GetChild(i).GetComponent<Mask>().self_damage_nullified = false;
                }
            }
        }
    }

    public void NetHit()
    {
        GameObject.Find("EnemyHolder").transform.GetChild(0).GetComponent<Contaminator>().net = true;
        GameObject.Find("EnemyHolder").transform.GetChild(0).GetComponent<Contaminator>().netted_burst = 3;
    }

    public void SelfDamage()
    {
        if(!self_damage_nullified) GetComponent<EffectDamage>().SelfDamage(null);
    }

    public void DealDamage(GameObject o)
    {
        o.GetComponent<EffectDamage>().DealDamage(null);
    }

    public void ShareSelfDamage()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            Debug.Log(i);
            if (RIE.GetChild(i).GetComponent<Weapon>().name == "Contaminator" || RIE.GetChild(i).GetComponent<Weapon>().name == "Gas granade")
            {
                RIE.GetChild(i).GetComponent<Weapon>().resultPhase.AddListener(() => { GetComponent<EffectDamage>().DealDamage(null); });
            }
        }
    }
}
