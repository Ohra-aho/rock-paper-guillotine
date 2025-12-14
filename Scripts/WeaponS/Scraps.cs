using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scraps : MonoBehaviour
{
    public bool heal;
    public bool damage;
    public bool armor;


    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 3;
        GetComponent<BuffController>().special_apply = true;

        if(heal)
        {
            GetComponent<Healing>().amount = 1;
        }
        if(damage)
        {
            GetComponent<BuffController>().damage_bonus = 1;
        }
        if(armor)
        {
            GetComponent<BuffController>().armor_bonus = 1;
        }
    }

    public void ApplyBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
