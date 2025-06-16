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
        GetComponent<Stacking>().stacks = 0;
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for(int i = 0; i < RI.childCount; i++)
        {
            if(RI.GetChild(i).GetComponent<Stacking>().stacks > 0)
            {
                GetComponent<Stacking>().IncreaseStacks(RI.GetChild(i).GetComponent<Stacking>().stacks);
            }
        }
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        damage_bonus = GetComponent<Stacking>().GiveAmountOfStackDividedBy(10);
        GetComponent<Weapon>().damage += damage_bonus;
    }
}
