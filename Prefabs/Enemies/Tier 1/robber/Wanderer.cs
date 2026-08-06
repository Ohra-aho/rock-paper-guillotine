using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
	public GameObject buff;
    public void DamageSpoils()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI"); 
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { 
				if(w.FindCertainBuff("Spoils_damage"))
				{
					Buff old_buff = w.GetCertainBuff("Spoils_damage").GetComponent<Buff>();
					old_buff.damage_buff++;
				} else
				{
					Buff buff_two = Instantiate(new_buff.gameObject, w.transform).GetComponent<Buff>();
					buff_two.temporary = false;
					buff_two.timer = 0;
					buff_two.damage_buff = 1;
					buff_two.endPhase = false;
					buff_two.id = "Spoils_damage";
				}
			};
			new_buff.AddBuff();
		}
	}

	public void ArmorSpoils()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI"); 
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { 
				if(w.FindCertainBuff("Spoils_armor"))
				{
					Buff old_buff = w.GetCertainBuff("Spoils_damage").GetComponent<Buff>();
					old_buff.armor_buff++;
				} else
				{
					Buff buff_two = Instantiate(new_buff.gameObject, w.transform).GetComponent<Buff>();
					buff_two.temporary = false;
					buff_two.timer = 0;
					buff_two.armor_buff = 1;
					buff_two.endPhase = false;
					buff_two.id = "Spoils_armor";
				}
			};
			new_buff.AddBuff();
		}
	}

	public void Hammer()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		GameObject nails = RIE.GetComponent<Realinventory>().FindWeapon("Long nails");
		nails.GetComponent<Stacking>().DecreaseStacks(2);
	}

	public void LongNails()
	{
		GetComponent<Stacking>().DecreaseStacks(1);
		if(GetComponent<Stacking>().stacks == 0)
		{
			GetComponent<PermanentDebuffer>().DestroyOpposingWeapon();
			GetComponent<Stacking>().IncreaseStacks(2);
		}
	}
}
