using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class ReinforcedGlass : MonoBehaviour
{
    private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().takeDamage = true;
		GetComponent<BuffController>().special = ApplyBuffs;
	}

	public void ApplyBuffs(Weapon w)
	{
		List<Weapon> weapons = w.player_owner.GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			GameObject old_buff = weapons[i].GetCertainBuff(GetComponent<Weapon>().name+"_2");
			if(old_buff != null)
			{
				old_buff.GetComponent<Buff>().timer = 2;
			} else
			{
				Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[i].transform).GetComponent<Buff>();
				new_buff.armor_buff = 1;
				new_buff.temporary = true;
				new_buff.timer = 2;
				new_buff.id = GetComponent<Weapon>().name+"_2";
			}
		}
	}
}
