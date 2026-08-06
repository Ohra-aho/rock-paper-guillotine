using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
	public Buff buff;

	public void ApplyBuff()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) =>
			{
				if(w.FindCertainBuff("Anvil_2"))
				{
					Buff old_buff = w.GetCertainBuff("Anvil_2").GetComponent<Buff>();
					old_buff.damage_buff++;
				} else
				{
					Buff buff_two = Instantiate(new_buff.gameObject, w.transform).GetComponent<Buff>();
					buff_two.temporary = false;
					buff_two.timer = 0;
					buff_two.damage_buff = 1;
					buff_two.id = "Anvil_2";
				}
			};
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.AddBuff();
		}
	}
}
