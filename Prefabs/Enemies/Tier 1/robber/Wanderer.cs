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
			Buff buff_two = Instantiate(buff.gameObject, RI.transform.GetChild(i).transform).GetComponent<Buff>();
			buff_two.temporary = true;
			buff_two.timer = 1000;
			buff_two.damage_buff = 1;
			buff_two.id = "Spoils_damage";
		}
	}

	public void ArmorSpoils()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI"); 
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			Buff buff_two = Instantiate(buff.gameObject, RI.transform.GetChild(i).transform).GetComponent<Buff>();
			buff_two.temporary = true;
			buff_two.timer = 1000;
			buff_two.armor_buff = 1;
			buff_two.id = "Spoils_armor";
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
