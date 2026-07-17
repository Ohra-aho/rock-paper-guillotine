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
				new_buff.temporary = false;
				new_buff.timer = 0;
				new_buff.damage_buff = 1;	
			};
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.AddBuff();
		}
	}
}
