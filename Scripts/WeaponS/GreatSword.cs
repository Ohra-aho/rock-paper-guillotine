using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSword : MonoBehaviour
{
	public void DealDamage()
	{
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		int current_hp = GetComponent<Weapon>().player_owner.HB.GiveCurrentHealth();
		int max_hp =  GetComponent<Weapon>().player_owner.HB.GiveMaxHealth();

		if(TC.player_healing > 0 && max_hp == current_hp - TC.GiveEffectivePlayerDamage())
		{
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		}
	}
}
