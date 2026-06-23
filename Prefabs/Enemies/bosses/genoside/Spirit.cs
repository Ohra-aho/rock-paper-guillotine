using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
	public GameObject buff;

	void Awake()
	{
		if(GetComponent<Weapon>().name == "Collect")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().damage_bonus = 2;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
		if(GetComponent<Weapon>().name == "Hunger")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
		if(GetComponent<Weapon>().name == "Smog")
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().armor_bonus = 3;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Cacophony()
	{
		List<int> indexes = new List<int>();
		List<Weapon> weapons = GetComponent<Weapon>().opponent.player_owner.GetWeapons();
		if(weapons.Count > 3)
		{
			for(int i = 0; i < 3; i++)
			{
				int index = Random.Range(0, weapons.Count);
				while(indexes.Contains(index))
				{
					index = Random.Range(0, weapons.Count);
				}
				indexes.Add(index);
			}
		} else if(weapons.Count <= 3)
		{
			for(int i = 0; i < weapons.Count; i++)
			{
				indexes.Add(i);
			}
		}

		for(int i = 0; i < indexes.Count; i++)
		{
			Buff new_buff = Instantiate(buff, weapons[indexes[i]].transform).GetComponent<Buff>();
			new_buff.type_change = MainController.Choise.useless;
			new_buff.endPhase = true;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.special = (Weapon w) =>
			{
				GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
				RIE.GetComponent<Realinventory>().FindWeapon("Grind").GetComponent<Stacking>().IncreaseStacks(2);	
			};
			new_buff.AddBuff();
		}
	}

	public void Collect()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		RIE.GetComponent<Realinventory>().FindWeapon("Grind").GetComponent<Stacking>().IncreaseStacks(2);	
	}

	public void Grind()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Healing>().amount = GetComponent<Stacking>().stacks;
			GetComponent<Healing>().Heal();
			GetComponent<Stacking>().stacks = 0; 
		} else
		{
			GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
			RIE.GetComponent<Realinventory>().FindWeapon("Collect").GetComponent<Weapon>().damage++;
		}
	}

	public void Hunger()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		if(RIE.GetComponent<Realinventory>().FindWeapon("Grind").GetComponent<Stacking>().stacks == 0)
		{
			GetComponent<BuffController>().Equip();
		}
	}

	public void Pulp()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		List<GameObject> poison = new List<GameObject>();
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
			{
				poison.Add(RI.transform.GetChild(i).gameObject);
			}
		}
		for(int i = 0; i < poison.Count; i++)
		{
			Destroy(poison[i]);
		}
	}

	public void Smog()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		int x = RIE.GetComponent<Realinventory>().FindWeapon("Grind").GetComponent<Stacking>().stacks;
		if(x > 0)
		{
			GetComponent<WeaponSpawner>().SpawnMultipleWeapons(x);
		} else
		{
			GetComponent<BuffController>().Equip();
		}
	}
}
