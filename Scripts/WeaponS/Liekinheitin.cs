using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liekinheitin : MonoBehaviour
{
    public void DealDamageFromArmor()
    {
        GetComponent<EffectDamage>().amount += GetComponent<Weapon>().opponent.armor * 2;
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<EffectDamage>().amount -= GetComponent<Weapon>().opponent.armor * 2;
    }
}
