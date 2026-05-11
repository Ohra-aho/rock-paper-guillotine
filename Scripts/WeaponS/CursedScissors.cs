using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedScissors : MonoBehaviour
{
    string[] debuff_names = {
		"Poison",
		"Dept",
		"Bleed",
		"#XG5J\"$P",
		"Hadle"
	};
	int damage_buff = 0;

	public void CalculateDamage()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		GetComponent<Weapon>().damage -= damage_buff;
		damage_buff = 0;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RecognizeDebuff(RI.transform.GetChild(i).GetComponent<Weapon>()))
			{
				damage_buff++;
			}
		}
		GetComponent<Weapon>().damage += damage_buff;
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
