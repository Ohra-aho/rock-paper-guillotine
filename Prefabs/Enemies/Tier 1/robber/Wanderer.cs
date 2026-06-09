using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    public int reward_tier = 1;

	public void GiveReward()
	{
		GetComponent<WeaponSpawner>().spawn_limit = reward_tier;
		int x = Random.Range(0, GetComponent<WeaponSpawner>().weapons.Count);
		for(int i = 0; i < reward_tier; i++)
		{
			GetComponent<WeaponSpawner>().SpawnSpecificWeapon(x);
			x++;
			if(x == GetComponent<WeaponSpawner>().weapons.Count)
			{
				x = 0;
			}
		}
	}

	public void IncreaseRewardTier()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Spoils")
			{
				RIE.transform.GetChild(i).GetComponent<Wanderer>().reward_tier++;
				if(RIE.transform.GetChild(i).GetComponent<Wanderer>().reward_tier > 3)
				{
					RIE.transform.GetChild(i).GetComponent<Wanderer>().reward_tier = 3;
				}
			}
		}
	}
}
