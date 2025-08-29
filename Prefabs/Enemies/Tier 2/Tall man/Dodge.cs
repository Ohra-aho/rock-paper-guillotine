using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
