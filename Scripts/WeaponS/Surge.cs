using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surge : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().heal = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = BuffDamage;
    }

    public void BuffDamage(Weapon w)
    {
        Buff new_buff = Instantiate(GetComponent<BuffController>().buff, this.transform).GetComponent<Buff>();
        new_buff.damage_buff = 1;
        new_buff.temporary = true;
        new_buff.timer = 1000;
        new_buff.id = GetComponent<Weapon>().name + "_2";
    }


}
