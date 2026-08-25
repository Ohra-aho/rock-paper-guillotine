using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerWeapons : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<Weapon>().name == "Embrace")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == "Maws"; };
			GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
			GetComponent<BuffController>().special_apply = true;
		}
		if(GetComponent<Weapon>().name == "Shell")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().armor_bonus = 1; 
			GetComponent<BuffController>().special_apply = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().temporary = true;
		}
	}

	public void Maws()
	{
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(TC.enemy_damage > 0 && TC.enemy_armor > 0)
		{
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		}
	}
}
