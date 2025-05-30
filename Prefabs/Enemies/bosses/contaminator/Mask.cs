using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public void NullifyContaminator()
    {

        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<EffectDamage>())
            {
                RIE.GetChild(i).GetComponent<EffectDamage>().amount = 0;
            }
        }
    }

    public void ResetContaminator()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        for (int i = 0; i < RIE.childCount; i++)
        {
            if (RIE.GetChild(i).GetComponent<EffectDamage>())
            {
                RIE.GetChild(i).GetComponent<EffectDamage>().amount = 1;
            }
        }
    }

    public void NetHit()
    {
        GameObject.Find("EnemyHolder").transform.GetChild(0).GetComponent<Contaminator>().net = true;
        GameObject.Find("EnemyHolder").transform.GetChild(0).GetComponent<Contaminator>().net_timer = 3;
        GameObject.Find("EnemyHolder").transform.GetChild(0).GetComponent<Contaminator>().netted_burst = 3;
    }
}
