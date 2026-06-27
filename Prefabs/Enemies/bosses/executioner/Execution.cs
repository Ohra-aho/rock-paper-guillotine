using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Execution : MonoBehaviour
{
	public GameObject judged;
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().armor_bonus = 3;
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Rock() {
		GetComponent<Healing>().amount++;
	}

	public void Paper()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		Weapon lowest = RIE.transform.GetChild(0).GetComponent<Weapon>();
		Weapon lowest_2 = RIE.transform.GetChild(1).GetComponent<Weapon>();

		for(int i = 1; i < RIE.transform.childCount; i++)
		{
			if(lowest != RIE.transform.GetChild(i).GetComponent<Weapon>())
			{
				if(RIE.transform.GetChild(i).GetComponent<Weapon>().armor < lowest.armor)
				{
					lowest = RIE.transform.GetChild(i).GetComponent<Weapon>();
				} else if(RIE.transform.GetChild(i).GetComponent<Weapon>().armor == lowest.armor)
				{
					int chance = Random.Range(0, 2);
					if(chance == 0)
					{
						lowest = RIE.transform.GetChild(i).GetComponent<Weapon>();
					}
				}
			}
		}

		for(int i = 1; i < RIE.transform.childCount; i++)
		{
			if(lowest_2 != RIE.transform.GetChild(i).GetComponent<Weapon>() && lowest != RIE.transform.GetChild(i).GetComponent<Weapon>() )
			{
				if(RIE.transform.GetChild(i).GetComponent<Weapon>().armor < lowest_2.armor)
				{
					lowest_2 = RIE.transform.GetChild(i).GetComponent<Weapon>();
				} else if(RIE.transform.GetChild(i).GetComponent<Weapon>().armor == lowest_2.armor)
				{
					int chance = Random.Range(0, 2);
					if(chance == 0)
					{
						lowest_2 = RIE.transform.GetChild(i).GetComponent<Weapon>();
					}
				}
			}
		}

		lowest.armor++;
		lowest_2.armor++;
	}

	public void Scissors()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			RIE.transform.GetChild(i).GetComponent<Weapon>().damage++;
		}
	}
	
	public void Judgement()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		GameObject dummy_weapon = Instantiate(judged, RI.transform);
		dummy_weapon.GetComponent<Weapon>().damage = GetComponent<Weapon>().opponent.damage;
		dummy_weapon.GetComponent<Weapon>().armor = GetComponent<Weapon>().opponent.armor;
		dummy_weapon.GetComponent<Weapon>().name = GetComponent<Weapon>().opponent.name;
		dummy_weapon.GetComponent<Weapon>().player = true;
		dummy_weapon.GetComponent<Weapon>().player_owner = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
		dummy_weapon.GetComponent<Weapon>().description = "Resets when used again.";
		if(!GetComponent<Weapon>().opponent.GetComponent<BuffController>().special_apply) GetComponent<Weapon>().opponent.GetComponent<BuffController>().Unequip();
		GameObject PWH = GameObject.Find("PlayerWheelHolder");
		WeaponSprite weapon_sprite = null;

		for(int i = 0; i < PWH.transform.GetChild(0).childCount-1; i++)
		{
			if(PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>() == GetComponent<Weapon>().opponent)
			{
				weapon_sprite = PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>();
				break;
			}
		}

		GameObject choise_panel = GameObject.Find("ChoisePanel");
		for(int i = 0; i < choise_panel.transform.childCount; i++)
		{
			if(choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon == GetComponent<Weapon>().opponent)
			{
				choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon = dummy_weapon.GetComponent<Weapon>();
			}
		}

		dummy_weapon.GetComponent<Execution>().judged = weapon_sprite.weapon;
		weapon_sprite.weapon = dummy_weapon;
	}

	public void EndJudgement()
	{
		GameObject PWH = GameObject.Find("PlayerWheelHolder");
		WeaponSprite weapon_sprite = null;

		for(int i = 0; i < PWH.transform.GetChild(0).childCount-1; i++)
		{
			if(PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>() == GetComponent<Weapon>())
			{
				weapon_sprite = PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>();
				break;
			}
		}

		GameObject choise_panel = GameObject.Find("ChoisePanel");
		for(int i = 0; i < choise_panel.transform.childCount; i++)
		{
			if(choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon == GetComponent<Weapon>())
			{
				choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon = GetComponent<Execution>().judged.GetComponent<Weapon>();
				break;
			}
		}

		weapon_sprite.weapon = GetComponent<Execution>().judged;
		if(!weapon_sprite.weapon.GetComponent<BuffController>().special_apply) weapon_sprite.weapon.GetComponent<BuffController>().Equip();
		Destroy(gameObject);
	}

	public void Pardon()
	{
		Buff new_buff = Instantiate(GetComponent<BuffController>().buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.type_change = MainController.Choise.voittamaton;
		new_buff.endPhase = true;
		new_buff.until_used = true;
		new_buff.special = (Weapon w) => { w.opponent.type = MainController.Choise.voittamaton; };
		new_buff.AddBuff();
	}

	public void Guilliotien()
	{
		GetComponent<Stacking>().IncreaseStacks(1);
		if(GetComponent<Stacking>().stacks == 10)
		{
			GetComponent<Weapon>().type = MainController.Choise.voittamaton;
		}
	}
}
