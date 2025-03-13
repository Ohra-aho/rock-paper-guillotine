using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puolustusmanifesti : MonoBehaviour
{
    public void CalculateDamage()
    {
        int damage = 0;

        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            damage += weapons[i].armor;
        }
        GetComponent<Weapon>().damage = damage;
    }
}
