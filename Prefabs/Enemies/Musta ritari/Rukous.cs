using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rukous : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Empower;
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name != GetComponent<Weapon>().name; };
    }

    public void Empower(Weapon weapon)
    {
        weapon.EffectDamage(weapon.damage / 2);
        GetComponent<BuffController>().Unequip();
    }

    public void Activate()
    {
        GetComponent<BuffController>().Equip();
    }
}
