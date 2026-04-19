using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public void IncreaseArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor++;
        }
    }

    int armor_found = 0;
    public void ScaleDamageFromArmor()
    {
        int damage = 0;

        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            damage += RIE.transform.GetChild(i).GetComponent<Weapon>().GiveEffectiveArmor();
        }

        if (armor_found < damage)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
        if (damage < armor_found)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
    }

    public void DropArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor = 0;
        }
    }

    public void NoDamageTaken()
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() == 0)
        {
            GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        }
    }
}
