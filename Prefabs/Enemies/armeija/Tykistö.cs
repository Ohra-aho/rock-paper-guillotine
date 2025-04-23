using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    public int damage;
    public void DealDamage()
    {
        if(GetComponent<Weapon>().stacks <= 3)
        {
            GetComponent<Weapon>().stacks++;
            GetComponent<Weapon>().EffectDamage(damage);
            damage = 3 - GetComponent<Weapon>().stacks;
        }
    }
}
