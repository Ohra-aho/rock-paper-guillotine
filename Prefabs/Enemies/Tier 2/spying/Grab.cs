using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Empower;
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().special_apply = true;
    }

    public void Empower(Weapon weapon)
    {
        weapon.EffectDamage(1);
    }

    public void Activate()
    {
        GetComponent<BuffController>().Equip();
    }
}
