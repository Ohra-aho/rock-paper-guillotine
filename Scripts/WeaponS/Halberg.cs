using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halberg : MonoBehaviour
{
	public GameObject buff;

    public void Buff()
	{
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(TC.player_damage > 0 && TC.player_armor > 0)
		{
			if(GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
			{
				GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>().damage_buff++;
			} else
			{
				Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
				new_buff.temporary = true;
				new_buff.timer = 1000;
				new_buff.until_used = true;
				new_buff.id = GetComponent<Weapon>().name;
				new_buff.damage_buff = 1;
				new_buff.visible_buff = true;
				new_buff.reminder = "+"+new_buff.damage_buff+" damage until used.";
			}
		}
	}
}
