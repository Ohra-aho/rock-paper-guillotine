using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{

    GameObject ri;
    int armor_bonus = 0;
    PlayerContoller player;

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().draw = true;
		GetComponent<BuffController>().special = ApplyBuff;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "If draws, +1 armor to all weapons for two turns.";
    }

    public void ApplyBuff(Weapon w)
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, RI.transform.GetChild(i)).GetComponent<Buff>();
			new_buff.armor_buff = 1;
			new_buff.temporary = true;
			new_buff.timer = 3;
			new_buff.id = GetComponent<Weapon>().name + "_two";
			new_buff.reminder = "+"+new_buff.armor_buff+" armor.";
		}
    }
}
