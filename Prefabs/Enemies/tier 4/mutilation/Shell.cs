using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().draw_winner = true;
			GetComponent<BuffController>().penetrating = true;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Rend()
	{
		GetComponent<Weapon>().damage += 1;
	}

	public void Howl()
	{
		Weapon player_choise = GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise;

		GameObject existing_buff = player_choise.GetCertainBuff(GetComponent<Weapon>().name);
		if(existing_buff != null)
		{
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		}
		else
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, player_choise.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.reminder = "After use, you take 2 damage.";
			new_buff.visible_debuff = true;
			new_buff.AddBuff();	
		}
	}
}
