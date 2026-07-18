using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().damage_modifier = true;
		GetComponent<BuffController>().special = NegateDamage;
		GetComponent<BuffController>().reminder = "Immune to damage.";
	}

	public void NegateDamage(Weapon w)
	{
		GameObject buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		if(buff.GetComponent<Buff>().timer < 2 && w.name != GetComponent<Weapon>().name)
		{
			TableController TC = GameObject.Find("Table").GetComponent<TableController>();
			TC.player_damage = 0;
			TC.player_direct_damage = 0;	
		}
	}
}
