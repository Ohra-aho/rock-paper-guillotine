using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaminator : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().damage_bonus = 1;
		}
	}

	public void Die()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}
}
