using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappolista : MonoBehaviour
{
    bool kill = false;

	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().damage_bonus = 1;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().special_apply = true;
	}

	public void Kill()
    {
        kill = true;
    }

	public void AddBuff()
	{
		if(kill)
		{
			GetComponent<BuffController>().Equip();
		}
		kill = false;
	}
}
