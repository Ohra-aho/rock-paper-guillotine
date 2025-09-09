using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGranade : MonoBehaviour
{
    public bool self_damage_nullified = false;
    public void DamageBoth()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        if(!self_damage_nullified) GetComponent<EffectDamage>().SelfDamage(null);
    }
}
