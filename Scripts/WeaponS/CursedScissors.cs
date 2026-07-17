using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedScissors : MonoBehaviour
{
	public GameObject buff;
    string[] debuff_names = {
		"Poison",
		"Weakness",
		"Bleed",
		"#XG5J\"$P",
		"Handle"
	};
	int damage_buff = 0;

	void Awake()
	{
		Buff own_buff = Instantiate(buff, transform).GetComponent<Buff>();
		own_buff.damage_buff = 0;
		own_buff.id = GetComponent<Weapon>().name;
	}

	public void CalculateDamage()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		GameObject own_buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		damage_buff = 0;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RecognizeDebuff(RI.transform.GetChild(i).GetComponent<Weapon>()))
			{
				damage_buff++;
			}
		}
		own_buff.GetComponent<Buff>().damage_buff = damage_buff;
	}

	public bool RecognizeDebuff(Weapon w)
	{
		for(int i = 0; i < debuff_names.Length; i++)
		{
			if(w.name == debuff_names[i])
			{
				return true;
			}
		}
		return false;
	}
}
