using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanaticWeapons : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().special_apply = true;
			GetComponent<BuffController>().damage_bonus = 1;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
		}
	}
}
