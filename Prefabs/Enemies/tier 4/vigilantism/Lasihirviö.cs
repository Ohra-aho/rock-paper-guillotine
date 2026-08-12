using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasihirviö : MonoBehaviour
{
	public GameObject buff;
	public void ConscrictLoss()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		RIE.GetComponent<Realinventory>().FindWeapon("Vindicate").GetComponent<Weapon>().damage--;
	} 

	public void ConscrictDraw()
	{
		string buff_1 = "Strike";
		string buff_2 = "Gaze_debuff";
		List<Weapon> weapons = GetComponent<Weapon>().opponent.player_owner.GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].FindCertainBuff(buff_1))
			{
				weapons[i].GetCertainBuff(buff_1).GetComponent<Buff>().temporary = false;
				weapons[i].GetCertainBuff(buff_1).GetComponent<Buff>().timer = 0;
				weapons[i].GetCertainBuff(buff_1).GetComponent<Buff>().reminder = "";
			}
			if(weapons[i].FindCertainBuff(buff_2))
			{
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().temporary = false;
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().timer = 0;
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().until_used = false;
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().reminder = "";
			}
		}
	}

	public void StrikePassive()
	{
		int amount = GetComponent<Weapon>().opponent.GiveEffectiveDamage();
		GetComponent<EffectDamage>().amount = amount;
		GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
	}

	public void Gaze()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.endPhase = true;
			new_buff.visible_debuff = true;
			new_buff.reminder = "After use, 2 of your weapons become \"useless\" for one turn.";
			new_buff.special = (Weapon w) =>
			{
				MakeTwoWeaponsUseless();
			};
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.AddBuff();
		}
	}

	public void MakeTwoWeaponsUseless()
	{
		List<Weapon> weapons = GetComponent<Weapon>().opponent.player_owner.GetWeapons();
		int index_1 = Random.Range(0, weapons.Count);
		int index_2 = Random.Range(0, weapons.Count);
		if(weapons.Count > 2)
		{
			while(index_2 == index_1)
			{
				index_2 = Random.Range(0, weapons.Count);
			}
		} else if(weapons.Count == 2)
		{
			index_1 = 0;
			index_2 = 1;
		} 

		if(!weapons[index_1].FindCertainBuff(GetComponent<Weapon>().name + "_debuff"))
		{
			Buff new_buff = Instantiate(buff, weapons[index_1].transform).GetComponent<Buff>();
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.type_change = MainController.Choise.useless;
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.visible_debuff = true;
			new_buff.AddBuff();	
		} else
		{
			weapons[index_1].GetCertainBuff(GetComponent<Weapon>().name + "_debuff").GetComponent<Buff>().timer = 2;
		}

		if(!weapons[index_2].FindCertainBuff(GetComponent<Weapon>().name + "_debuff"))
		{
			Buff new_buff = Instantiate(buff, weapons[index_2].transform).GetComponent<Buff>();
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.type_change = MainController.Choise.useless;
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.visible_debuff = true;
			new_buff.AddBuff();	
		} else
		{
			weapons[index_2].GetCertainBuff(GetComponent<Weapon>().name + "_debuff").GetComponent<Buff>().timer = 2;
		}
	}
}
