using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chell : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = BreakArmor;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void BreakArmor(Weapon w)
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor = 0;
        }
    }
}
