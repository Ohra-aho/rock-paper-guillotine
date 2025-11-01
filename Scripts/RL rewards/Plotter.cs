using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plotter : MonoBehaviour
{
    public void Chosen()
    {
        ApplyBuff();
    }

    public void ApplyBuff()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            if (weapon.GetComponent<EffectDamage>() && !weapon.GetComponent<Weapon>().penetrating)
            {
                weapon.GetComponent<EffectDamage>().armor_piercing = true;
            }
        }
    }
}

