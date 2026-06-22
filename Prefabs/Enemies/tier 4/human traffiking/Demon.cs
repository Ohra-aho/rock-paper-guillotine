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
			GetComponent<BuffController>().timer = 0;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Process()
	{
		if(GetComponent<Stacking>().stacks >= 2)
		{
			int amount = GetComponent<Stacking>().stacks;
			GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
			RIE.GetComponent<Realinventory>().FindWeapon("Utilize").GetComponent<Stacking>().IncreaseStacks(amount / 2);
			GetComponent<Stacking>().DecreaseStacks(amount);
		}
	}

	public void Trap(int tier)
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		List<GameObject> weapons_to_destroy = new List<GameObject>();

		if(RI.transform.childCount - weapons.Count < tier) tier = RI.transform.childCount - weapons.Count;

		if(weapons.Count < RI.transform.childCount)
		{
			while(weapons_to_destroy.Count < tier)
			{
				for(int i = 0; i < RI.transform.childCount; i++)
				{
					if(!weapons.Contains(RI.transform.GetChild(i).GetComponent<Weapon>()))
					{
						int rand = Random.Range(0, 2);
						if(rand == 0)
						{
							weapons_to_destroy.Add(RI.transform.GetChild(i).gameObject);
						}
					}
				}
			}
		}
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < weapons_to_destroy.Count; i++)
		{
			Destroy(weapons_to_destroy[i]);
			RIE.GetComponent<Realinventory>().FindWeapon("Process").GetComponent<Stacking>().IncreaseStacks(1);
		}
	}

	public void Utilize()
	{
		int amount = GetComponent<Stacking>().stacks;
		GetComponent<WeaponSpawner>().SpawnMultipleWeapons(amount);
		GetComponent<Stacking>().DecreaseStacks(amount);
	}

	public void UtilizeTwo()
	{
		int amount = GetComponent<Stacking>().stacks;
		GetComponent<BuffController>().timer = amount + 1;
		GetComponent<BuffController>().Equip();
	}
}
