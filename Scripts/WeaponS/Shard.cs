using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{

	void Awake()
	{
		GetComponent<BuffController>().special_apply = true;
	}
	public void ApplyBuffs()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[i].transform).GetComponent<Buff>();
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) =>
			{
				new_buff.RemoveBuff();
				new_buff.timer = 1000;
				new_buff.damage_buff = 2;
				new_buff.AddBuff();	
			};
			new_buff.AddBuff();
		}
	}
}
