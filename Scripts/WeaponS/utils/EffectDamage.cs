using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    public int amount;
    public bool armor_piercing;
    public void DealDamage(Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.EffectDamage(amount);
            if(weapon.deal_effect_damage != null)
                weapon.deal_effect_damage.Invoke();
            
        }
        else
        {
            GetComponent<Weapon>().EffectDamage(amount);
            if (GetComponent<Weapon>().deal_effect_damage != null)
                GetComponent<Weapon>().deal_effect_damage.Invoke();
        }
    }

    public void SelfDamage(Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.SelfDamage(amount);
            if (weapon.deal_effect_damage != null)
                weapon.deal_effect_damage.Invoke();

        }
        else
        {
            GetComponent<Weapon>().SelfDamage(amount);
            if (GetComponent<Weapon>().deal_effect_damage != null)
                GetComponent<Weapon>().deal_effect_damage.Invoke();
        }
    }
}
