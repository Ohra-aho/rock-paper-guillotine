using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    bool activated = false;
    public void NullifyContaminator()
    {
        if(!activated)
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
            activated = true;
        }
    }

    public void ShareSelfDamage()
    {
        if(!activated)
        {
            Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
            for (int i = 0; i < RIE.childCount; i++)
            {
                if (RIE.GetChild(i).GetComponent<Weapon>().name == "Contaminator")
                {
                    RIE.GetChild(i).GetComponent<Weapon>().endPhase.AddListener(() => { GetComponent<EffectDamage>().DealSetDamage(1); });
                }
                if (RIE.GetChild(i).GetComponent<Weapon>().name == "Gas granade")
                {
                    RIE.GetChild(i).GetComponent<Weapon>().resultPhase.AddListener(() => { GetComponent<EffectDamage>().DealSetDamage(1); });
                }
            }
            activated = true;
        }
    }
}
