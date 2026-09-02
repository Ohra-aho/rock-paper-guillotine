using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Process()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			int amount = GetComponent<Stacking>().stacks;
			GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
			RIE.GetComponent<Realinventory>().FindWeapon("Utilize").GetComponent<Stacking>().IncreaseStacks(amount);
			GetComponent<Stacking>().DecreaseStacks(amount);
		} else
		{
			GetComponent<WeaponSpawner>().SpawnRandomWeapon();
		}
	}

	public void Trap()
	{
		if(!GetComponent<Weapon>().opponent.GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.destructive = true;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) =>
			{
				GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
				for(int i = 0; i < RIE.transform.childCount; i++)
				{
					if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Process")
					{
						RIE.transform.GetChild(i).GetComponent<Stacking>().IncreaseStacks(1);
					}
				}	
			};
			new_buff.reminder = "After use, self-destructs and Process gains a point.";
			new_buff.visible_debuff = true;
			new_buff.AddBuff();	
		}
	}

	public void Utilize()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			int amount = GetComponent<Stacking>().stacks;
			GetComponent<WeaponSpawner>().SpawnMultipleWeapons(amount);
			GetComponent<Stacking>().DecreaseStacks(amount);	
		} else
		{
			GetComponent<BuffController>().Equip();
		}
	}
}
