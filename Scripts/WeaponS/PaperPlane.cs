using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
	public void DealDamage()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
		int armor_found = 0;
		for(int i = 0; i < weapons.Count; i++)
		{
			armor_found += weapons[i].GetComponent<Weapon>().GiveEffectiveArmor(); 
		}
		if(armor_found > 0)
		{
			GetComponent<EffectDamage>().amount = armor_found;
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
			GetComponent<SelfDestruct>().Destruct();
		}
	}
}
