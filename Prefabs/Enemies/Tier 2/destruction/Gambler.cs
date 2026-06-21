using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : MonoBehaviour
{
	public GameObject buff;

	public void Flames()
	{
		GameObject opponent = GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise.gameObject;
		if(!FindOwnBuff(opponent))
		{
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.endPhase = true;
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.special = (Weapon w) => { GetComponent<EffectDamage>().SelfDamage(w); };
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.AddBuff();
		}
	}

	public bool FindOwnBuff(GameObject weapon)
	{
		for(int i = 0; i < weapon.transform.childCount; i++)
		{
			if(weapon.transform.GetChild(i).GetComponent<Buff>())
			{
				if(weapon.transform.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void Roar()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			RIE.transform.GetChild(i).GetComponent<Weapon>().damage++;
		}
	}
}
