using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puolustusmanifesti : MonoBehaviour
{
    int armor_found = 0;
    public void CalculateDamage()
    {
        int damage = 0;

        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            damage += weapons[i].armor;
        }

        if(armor_found < damage)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
        if(damage < armor_found)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
    }
}
