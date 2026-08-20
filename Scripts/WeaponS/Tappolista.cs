using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappolista : MonoBehaviour
{
    int kills = 0;
	bool kill = false;

	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().damage_bonus = 1;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().special_apply = true;

		GetComponent<Weapon>().special_token = () =>
		{
			return kills;
		};
		GetComponent<Weapon>().load_special_token = () =>
		{
			if(GetComponent<Weapon>().token > 0)
			{
				kills = GetComponent<Weapon>().token;
				GetComponent<BuffController>().damage_bonus = kills;
			}
		};
	}

	public void Kill()
    {
        kills++;
		GetComponent<BuffController>().damage_bonus = kills;
		kill = true;
    }

	public void AddBuff()
	{
		if(kills > 0)
		{
			GetComponent<BuffController>().Equip();
		}
		kill = false;
	}

	public void NoKIll()
	{
		if(!kill)
		{
			kills = 0;
		}
	}
}
