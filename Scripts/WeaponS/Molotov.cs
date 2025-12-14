using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    private void Awake()
    {
        /*GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 3;
        GetComponent<BuffController>().special_apply = true;*/
        GetComponent<BuffController>().special_apply = true;
    }

    public void DealDamage(Weapon w)
    {
        GetComponent<EffectDamage>().SelfDamage(w);
    }

    public void ApplyBuffs()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for(int i = 0; i < RIE.transform.childCount; i++) {
            GameObject new_buff = Instantiate(GetComponent<BuffController>().buff, RIE.transform.GetChild(i));
            new_buff.GetComponent<Buff>().special = DealDamage;
            new_buff.GetComponent<Buff>().endPhase = true;
            new_buff.GetComponent<Buff>().temporary = true;
            new_buff.GetComponent<Buff>().timer = 3;
            new_buff.GetComponent<Buff>().AddBuff();
        }
    }

}
