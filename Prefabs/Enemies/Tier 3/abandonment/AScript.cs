using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AScript : MonoBehaviour
{
	int previous_x = 0;
	public int identity = 0;

	void Awake()
	{
		switch(identity)
		{
			case 0:
				GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
				GetComponent<BuffController>().special_apply = true;
				GetComponent<BuffController>().temporary = true;
				GetComponent<BuffController>().timer = 2;
				GetComponent<BuffController>().destructive = true;
				GetComponent<BuffController>().endPhase = true;
				GetComponent<BuffController>().special = Benefit;
				GetComponent<BuffController>().visible_debuff = true;
				GetComponent<BuffController>().reminder = "After use, self-destructs.";
				break;
			case 1:
				GetComponent<BuffController>().buff_requirement = (Weapon w) => { 
					return w.name != GetComponent<Weapon>().name &&
					w.name != "Smite" && 
					w.name != "Mercy" && 
					w.name != "Sanctuary"; 
				};
				GetComponent<BuffController>().special_apply = true;
				GetComponent<BuffController>().temporary = true;
				GetComponent<BuffController>().timer = 2;
				GetComponent<BuffController>().destructive = true;
				GetComponent<BuffController>().endPhase = true;
				GetComponent<BuffController>().special = (Weapon w) => { GetComponent<WeaponSpawner>().SpawnRandomWeapon(); };
				GetComponent<BuffController>().visible_debuff = true;
				GetComponent<BuffController>().reminder = "After use, self-destructs.";
				break;
			case 2:
				GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
				GetComponent<BuffController>().special_apply = true;
				GetComponent<BuffController>().temporary = true;
				GetComponent<BuffController>().timer = 2;
				GetComponent<BuffController>().destructive = true;
				GetComponent<BuffController>().endPhase = true;
				GetComponent<BuffController>().special = RemoveDebuffs;
				GetComponent<BuffController>().visible_debuff = true;
				GetComponent<BuffController>().reminder = "After use, self-destructs.";
				break;
		}
	}

	public void AppluEffects()
	{
		switch(identity)
		{
			case 0: if(GetComponent<Weapon>().GiveEffectiveType() != MainController.Choise.voittamaton) GetComponent<BuffController>().Equip();  break;
			case 1: GetComponent<BuffController>().Equip(); break;
			case 2: GetComponent<BuffController>().Equip(); break;
		}
	}

	public void Benefit(Weapon w)
	{
		Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name + "_buff_1";
		new_buff.damage_buff = 1;
		new_buff.temporary = true;
		new_buff.timer = 1000;

		Buff new_buff_2 = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
		new_buff_2.id = GetComponent<Weapon>().name + "_buff_2";
		new_buff_2.type_change = MainController.Choise.voittamaton;
		new_buff_2.temporary = true;
		new_buff_2.timer = 2;
		new_buff_2.visible_buff = true;
		new_buff_2.AddBuff();
	}

	public void RemoveDebuffs(Weapon w)
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
		int counter = 0;
		for(int i = RI.transform.childCount-1; i >= 0; i--)
		{
			if(!weapons.Contains(RI.transform.GetChild(i).GetComponent<Weapon>()))
			{
				if(
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Bleed" || 
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison" || 
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Weakness" || 
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Dismemberment"
				)
				{
					Destroy(RI.transform.GetChild(i).gameObject);
					counter++;
					if(counter == 2) break;
				}
			}
		}
	}

}
