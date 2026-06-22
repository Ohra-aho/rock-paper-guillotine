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
			}
			if(weapons[i].FindCertainBuff(buff_2))
			{
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().temporary = false;
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().timer = 0;
				weapons[i].GetCertainBuff(buff_2).GetComponent<Buff>().until_used = false;
			}
		}
	}

	public void StrikePassive()
	{
		if(GetComponent<Weapon>().opponent.type == MainController.Choise.sakset)
		{
			List<Weapon> weapons = GetComponent<Weapon>().opponent.player_owner.GetComponent<PlayerContoller>().GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				if(weapons[i].FindCertainBuff("Strike"))
				{
					weapons[i].GetCertainBuff("Strike").GetComponent<Buff>().armor_buff--;
				} else
				{
					Buff new_buff = Instantiate(buff, weapons[i].transform).GetComponent<Buff>();
					new_buff.id = "Strike";
					new_buff.temporary = true;
					new_buff.timer = 1000;
					new_buff.armor_buff = -1;
					new_buff.AddBuff();
				}
			}
		}
	}
}
