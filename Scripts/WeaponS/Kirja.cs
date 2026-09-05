using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{
	bool used = false;
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 3;
		GetComponent<BuffController>().armor_bonus = 1;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().visible_buff = true;
		GetComponent<BuffController>().reminder = "+1 armor.";
    }

	public void GiveBuffs()
	{
		if(!used)
		{
			used = true;
			GetComponent<BuffController>().Equip();
		}
	}

	public void Reset()
	{
		used = false;
	}
}
