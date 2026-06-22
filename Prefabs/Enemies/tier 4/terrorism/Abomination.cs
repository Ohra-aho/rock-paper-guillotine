using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abomination : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().armor_bonus = 3;
			GetComponent<BuffController>().timer = 4;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().special_apply = true;
		}
	}
	public void Burst()
	{
		GetComponent<WeaponSpawner>().SpawnMultipleWeapons(3);
		GetComponent<Weapon>().owner.HB.InstaKill();
	}

	public void Lash()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			if(RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff("Reject"))
			{
				GameObject reject = RIE.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff("Reject");
				reject.GetComponent<Buff>().RemoveBuff();
				Destroy(reject);
			}
		}
	}
}
