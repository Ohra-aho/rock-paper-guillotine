using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<Stacking>(); };
		GetComponent<BuffController>().gain_points = true;
		GetComponent<BuffController>().special = BuffSelf;
	}

	public void BuffSelf(Weapon w)
	{
		if(GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff old_buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>();
			old_buff.damage_buff++;
			old_buff.reminder = old_buff.damage_buff + " damage until used.";

		} else
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.damage_buff = 1;
			new_buff.temporary = true;
			new_buff.until_used = true;
			new_buff.visible_buff = true;
			new_buff.reminder = new_buff.damage_buff + " damage until used.";
			new_buff.AddBuff();
		}
	}
}
