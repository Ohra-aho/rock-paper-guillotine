using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greataxe : MonoBehaviour
{
    public void Tenacity()
    {
        GetComponent<EffectDamage>().amount = GetComponent<Weapon>().GiveEffectiveDamage() / 2;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
