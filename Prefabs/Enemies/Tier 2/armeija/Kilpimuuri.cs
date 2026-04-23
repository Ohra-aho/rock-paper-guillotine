using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kilpimuuri : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().special = ApplyBuffs;
    }

    public void ApplyBuffs(Weapon w)
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name + "_2";
            new_buff.temporary = true;
            new_buff.timer = 2;
            new_buff.armor_buff = 1;
            new_buff.AddBuff();
        }
    }
}
