using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilikirja : MonoBehaviour
{
    int damage_bonus = 0;
    public void CheckForPoints()
    {
        GetComponent<Weapon>().damage -= damage_bonus;
        damage_bonus = 0;
        GetComponent<Weapon>().stacks = 0;
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for(int i = 0; i < RI.childCount; i++)
        {
            if(RI.GetChild(i).GetComponent<Weapon>().stacks > 0)
            {
                GetComponent<Weapon>().stacks += RI.GetChild(i).GetComponent<Weapon>().stacks;
            }
        }
        damage_bonus = GetComponent<Weapon>().stacks / 10;
        GetComponent<Weapon>().damage += damage_bonus;
    }
}
