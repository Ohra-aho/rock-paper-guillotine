using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savimöykky : MonoBehaviour
{
    private int damage_mod;
    private int armor_mod;

    private void Awake()
    {
        damage_mod = 3;
        armor_mod = 0;
        GetComponent<Weapon>().damage = damage_mod;
        GetComponent<Weapon>().armor = armor_mod;
    }

    public void TakingDamage()
    {
        armor_mod++;
        damage_mod--;
        if(armor_mod > 3)
        {
            armor_mod = 3;
        }
        if(damage_mod < 0)
        {
            damage_mod = 0;
        }
        GetComponent<Weapon>().damage = damage_mod;
        GetComponent<Weapon>().armor = armor_mod;
    }

    public void DealingDamage()
    {
        armor_mod--;
        damage_mod++;
        if (damage_mod < 0)
        {
            damage_mod = 0;
        }
        if (armor_mod > 3)
        {
            armor_mod = 3;
        }
        GetComponent<Weapon>().damage = damage_mod;
        GetComponent<Weapon>().armor = armor_mod;
    }
}
