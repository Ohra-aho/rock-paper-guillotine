using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    [HideInInspector] public int armor_bonus = 1;
    public void IncreaseArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor += armor_bonus;
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

    public void SetArmorToPermanent()
    {
        GetComponent<Weapon>().armor = GetComponent<Weapon>().GiveEffectiveArmor();
    }

    public void DropArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor -= armor_bonus;
        }
    }

    public void IncreaseArmorBonus()
    {
        armor_bonus++;
    }

    public void NoDamageTaken()
    {
        if(GameObject.Find("Table").GetComponent<TableController>().enemy_damage == 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
