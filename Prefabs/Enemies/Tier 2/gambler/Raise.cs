using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raise : MonoBehaviour
{
    public GameObject buff;

    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special_apply = true;
    }

    public void BuffOpposingWeapons()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");

        for (int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            GameObject new_buff = Instantiate(buff, weapon.transform);
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
            new_buff.GetComponent<Buff>().temporary = true;
            new_buff.GetComponent<Buff>().timer = 1;
            new_buff.GetComponent<Buff>().damage_buff = 2;
            new_buff.GetComponent<Buff>().AddBuff();
        }
    }

    public void ApplyBuffs()
    {
        GetComponent<BuffController>().Equip();
        BuffOpposingWeapons();
    }
}
