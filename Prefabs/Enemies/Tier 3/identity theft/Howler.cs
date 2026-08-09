using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Howler : MonoBehaviour
{
	public GameObject buff;
	public GameObject torn;
    public void Stitch()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Stacking>().DecreaseStacks(1);
			GetComponent<Healing>().Heal();
		}
	}

	public void Collapse()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		GameObject onslaught = RIE.GetComponent<Realinventory>().FindWeapon("Onslaught");
		if(onslaught != null)
		{
			GameObject old_buff = onslaught.GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
			if(old_buff == null)
			{
				Buff new_buff = Instantiate(buff, onslaught.transform).GetComponent<Buff>();
				new_buff.id = GetComponent<Weapon>().name;
				new_buff.type_change = MainController.Choise.useless;
				new_buff.temporary = true;
				new_buff.until_used = true;
				new_buff.AddBuff();
			}
		}
	}

	public void Tear()
	{
		Judgement();
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Stitch")
			{
				RIE.transform.GetChild(i).GetComponent<Stacking>().IncreaseStacks(1);
				break;
			}
		}
	}


	public void Judgement()
	{
		PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		GameObject dummy_weapon = Instantiate(torn, RI.transform);
		GetComponent<Weapon>().opponent = player.chosenWeapon.GetComponent<Weapon>();
		dummy_weapon.GetComponent<Weapon>().damage = GetComponent<Weapon>().opponent.damage;
		dummy_weapon.GetComponent<Weapon>().armor = GetComponent<Weapon>().opponent.armor;
		dummy_weapon.GetComponent<Weapon>().name = GetComponent<Weapon>().opponent.name;
		dummy_weapon.GetComponent<Weapon>().type = GetComponent<Weapon>().opponent.og_type;
		dummy_weapon.GetComponent<Weapon>().og_type = GetComponent<Weapon>().opponent.og_type;
		dummy_weapon.GetComponent<Weapon>().player = true;
		dummy_weapon.GetComponent<Weapon>().player_owner = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
		dummy_weapon.GetComponent<Weapon>().description = "Resets at the end of the fight.";
		player.chosenWeapon = dummy_weapon;

		GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise = dummy_weapon.GetComponent<Weapon>();
		if(GetComponent<Weapon>().opponent.GetComponent<BuffController>())
		{
			if(!GetComponent<Weapon>().opponent.GetComponent<BuffController>().special_apply) 
				GetComponent<Weapon>().opponent.GetComponent<BuffController>().Unequip();
		} else
		{
			GetComponent<Weapon>().opponent.unEquip.Invoke();
		}
		GameObject PWH = GameObject.Find("PlayerWheelHolder");
		WeaponSprite weapon_sprite = null;

		for(int i = 0; i < PWH.transform.GetChild(0).childCount-1; i++)
		{
			if(PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
			{
				if(PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>() == GetComponent<Weapon>().opponent)
				{
					weapon_sprite = PWH.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>();
					break;
				}	
			}
		}

		GameObject choise_panel = GameObject.Find("ChoisePanel");
		for(int i = 0; i < choise_panel.transform.childCount; i++)
		{
			if(choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon != null)
			{
				if(choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon == GetComponent<Weapon>().opponent)
				{
					choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon = dummy_weapon.GetComponent<Weapon>();
				}
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
}
