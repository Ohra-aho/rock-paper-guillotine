using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raivo : MonoBehaviour
{
    private void Awake()
    {
        //GetComponent<BuffController>().special_removal = Remove;
        GetComponent<BuffController>().special = Empower;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Empower(Weapon weapon)
    {
       
        GameObject true_weapon_holder = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, true_weapon_holder.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.temporary = true;
            new_buff.timer = 2;
            new_buff.damage_buff = 2;
            new_buff.id = GetComponent<Weapon>().name + "_2";
            new_buff.AddBuff();
        }
    }

    public void Debuff()
    {
        GameObject true_weapon_holder = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, true_weapon_holder.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.temporary = true;
            new_buff.timer = 2;
            new_buff.damage_buff = -1;
            new_buff.id = GetComponent<Weapon>().name + "_3";
            new_buff.AddBuff();
        }
    }
}
