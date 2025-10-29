using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    public int amount;
    public bool armor_piercing;
    public void DealDamage(Weapon weapon)
    {
        if (weapon != null) weapon.EffectDamage(amount);
        else GetComponent<Weapon>().EffectDamage(amount);
    }

    public void SelfDamage(Weapon weapon)
    {
        if (weapon != null) weapon.SelfDamage(amount);
        else GetComponent<Weapon>().SelfDamage(amount);
    }
}
