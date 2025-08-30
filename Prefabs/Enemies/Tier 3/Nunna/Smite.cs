using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
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
