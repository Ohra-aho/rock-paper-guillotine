using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public void NullifyContaminator()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder").transform.GetChild(0).gameObject;

        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<EffectDamage>())
            {
                RIE.GetChild(i).GetComponent<EffectDamage>().amount = 0;   
            }
        }
    }

    public void ShareSelfDamage()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<Weapon>().name == "Contaminator" || RIE.GetChild(i).GetComponent<Weapon>().name == "Gas granade")
            {
                RIE.GetChild(i).GetComponent<Weapon>().resultPhase.AddListener(() => { GetComponent<EffectDamage>().DealSetDamage(1); });
            }
        }
    }
}
