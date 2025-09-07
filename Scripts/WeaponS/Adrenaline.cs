using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = SetNewBuffs;
        GetComponent<BuffController>().takeDamage = true;
    }

    public void SetNewBuffs(Weapon w)
    {
        GameObject real_inventory = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < real_inventory.transform.childCount; i++)
        {
            Transform weapon = real_inventory.transform.GetChild(i);

            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapon).GetComponent<Buff>();
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name+"_2";
            new_buff.GetComponent<Buff>().damage_buff = 1;
            new_buff.timer = 2;
            new_buff.temporary = true;
            new_buff.GetComponent<Buff>().AddBuff();
        }
    }
}
