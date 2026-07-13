using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
	public GameObject buff;
	bool disabled = false;
	int disable_counter = 0;

	void Awake()
	{
		if(GetComponent<Weapon>().name == "Hedgehog")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().endPhase = true;
			GetComponent<BuffController>().special = (Weapon w) =>
			{
				TableController TC = GameObject.Find("Table").GetComponent<TableController>();
				int damage = TC.player_damage;
				int armor = TC.player_armor;
				bool pierce = w.opponent.penetrating;
				if(damage > 0)
				{
					if(damage > armor || pierce)
					{
						GameObject.Find("Table").GetComponent<TableController>().player_damage = 0;
						GetComponent<EffectDamage>().DealDamage(w);
						GetComponent<BuffController>().Unequip();	
					}
				}
			};
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Chain()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			Buff new_buff = Instantiate(buff, weapons[i].transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.damage_buff = -1;
			new_buff.reminder = "-1 damage";
			new_buff.AddBuff();
		}
	}

	public void Jar()
	{
		if(!disabled)
		{
			List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
			int index = Random.Range(0, weapons.Count);

			GameObject existing_buff = weapons[index].GetCertainBuff(GetComponent<Weapon>().name);
			if(existing_buff != null)
			{
				existing_buff.GetComponent<Buff>().timer = 2;
			}
			else
			{
				Buff new_buff = Instantiate(buff, weapons[index].transform).GetComponent<Buff>();
				new_buff.id = GetComponent<Weapon>().name;
				new_buff.temporary = true;
				new_buff.timer = 2;
				new_buff.type_change = MainController.Choise.useless;
				new_buff.reminder = "Made \"useless\"";
				new_buff.AddBuff();	
			}
		} else
		{
			disable_counter--;
			if(disable_counter <= 0)
			{
				disabled = false;
				disable_counter = 0;
			}
		}
	}

	public void JarDisabled()
	{
		disabled = true;
		disable_counter = 2;
	}



}
