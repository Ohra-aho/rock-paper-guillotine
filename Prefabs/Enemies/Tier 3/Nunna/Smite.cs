using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        //GetComponent<BuffController>().
    }

    bool damage_dealt = false;
    public void Flagelation()
    {
        if(!damage_dealt) GetComponent<EffectDamage>().SelfDamage(null);
        damage_dealt = false;
    }

    public void DealingDamage()
    {
        damage_dealt = true;
    }
}
