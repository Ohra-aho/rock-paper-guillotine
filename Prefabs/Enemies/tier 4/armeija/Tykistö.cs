using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    public int damage;
    public void DealDamage()
    {
        if(GetComponent<Stacking>().stacks <= 3)
        {
            GetComponent<Stacking>().IncreaseStacks(1);
            GetComponent<Weapon>().EffectDamage(damage);
            damage = 3 - GetComponent<Stacking>().stacks;
        }
    }
}
