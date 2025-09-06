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

    public void ScaleDamageFromArmor(int base_damage)
    {
        GetComponent<Weapon>().damage = base_damage;
        GetComponent<Weapon>().damage += GetComponent<Weapon>().armor;
    }

    public void DropArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor = 0;
        }
    }
}
