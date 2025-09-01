using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public void Retaliate()
    {
        int damage_taken = GetComponent<DamageInteractions>().CalculateTakenDamage();
        if(damage_taken <= 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }

    public void Fist()
    {
        int dealt_damage = GetComponent<DamageInteractions>().CalculateDealtDamage();
        if(dealt_damage <= 0)
        {
            GetComponent<EffectDamage>().SelfDamage(null);
            GetComponent<Weapon>().damage++;
        }
    }

    public void Spikes()
    {
        int damage_taken = GetComponent<DamageInteractions>().CalculateTakenDamage();
        if (damage_taken > 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<EffectDamage>().SelfDamage(null);

            GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

            for (int i = 0; i < RIE.transform.childCount; i++)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage++;
                if (RIE.transform.GetChild(i).GetComponent<Weapon>().armor > 0)
                {
                    RIE.transform.GetChild(i).GetComponent<Weapon>().armor--;
                }
            }
        }
    }
}
