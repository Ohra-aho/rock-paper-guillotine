using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteScript : MonoBehaviour
{
	bool active = false;

	public int identity = 0;

	void Awake()
	{
		switch(identity)
		{
			case 0:
				GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
				GetComponent<BuffController>().armor_bonus = 1;
				GetComponent<BuffController>().temporary = true;
				GetComponent<BuffController>().until_used = true;
				GetComponent<BuffController>().timer = 1000;
				GetComponent<BuffController>().special_apply = true;
				GetComponent<BuffController>().visible_buff = true;
				GetComponent<BuffController>().reminder = "+1 armor until used.";
				break;
			case 1:
				GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
				GetComponent<BuffController>().damage_bonus = -1;
				GetComponent<BuffController>().temporary = true;
				GetComponent<BuffController>().until_used = true;
				GetComponent<BuffController>().timer = 1000;
				GetComponent<BuffController>().special_apply = true;
				GetComponent<BuffController>().visible_debuff = true;
				GetComponent<BuffController>().reminder = "-1 damage until used.";
				break;
		}
	}

	public void Activate()
	{
		if(!active)
		{
			active = true;
			GetComponent<HealthIncrease>().ForceHealthDecrease();
			GetComponent<BuffController>().Equip();
		}
	}

	public void Deactivate()
	{
		if(active)
		{
			active = false;
			GetComponent<HealthIncrease>().ForceHealthIncrease();
		}
	}
}
