using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteScript : MonoBehaviour
{
	bool active = false;

	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().armor_bonus = 1;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().until_used = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().special_apply = true;
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
