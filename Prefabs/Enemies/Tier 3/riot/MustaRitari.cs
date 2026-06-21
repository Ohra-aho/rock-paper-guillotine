using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MustaRitari : MonoBehaviour
{
	public GameObject buff;
	int weaknesses = 0;
	int poisons = 0;
	int bleeds = 0;
    public void Beacon()
	{
		GetComponent<Weapon>().opponent.type = MainController.Choise.voittamaton;
		GetComponent<Weapon>().opponent.AddComponent<SelfDestruct>();
		GetComponent<Weapon>().opponent.endPhase.AddListener(GetComponent<Weapon>().opponent.GetComponent<SelfDestruct>().Destruct);
	}

	public void Trample()
	{
		weaknesses = 0;
		poisons = 0;
		bleeds = 0;
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Weakness")
			{
				weaknesses++;
			}
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
			{
				poisons++;
			}
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Bleed")
			{
				bleeds++;
			}
		}

		GameObject w_buff = GetComponent<Weapon>().GetCertainBuff("w_buff");
		GameObject p_buff = GetComponent<Weapon>().GetCertainBuff("p_buff");
		GameObject b_buff = GetComponent<Weapon>().GetCertainBuff("b_buff");

		w_buff.GetComponent<Buff>().RemoveBuff();
		p_buff.GetComponent<Buff>().RemoveBuff();
		b_buff.GetComponent<Buff>().RemoveBuff();

		w_buff.GetComponent<Buff>().damage_buff = weaknesses*2;
		p_buff.GetComponent<Buff>().armor_buff = poisons;
		if(bleeds > 0) b_buff.GetComponent<Buff>().draw_winner = true;
		else b_buff.GetComponent<Buff>().draw_winner = false;

		w_buff.GetComponent<Buff>().AddBuff();
		p_buff.GetComponent<Buff>().AddBuff();
		b_buff.GetComponent<Buff>().AddBuff();
	}

	public void ApplyTrampleBuffs()
	{
		Buff w_buff = Instantiate(buff, transform).GetComponent<Buff>();
		w_buff.id = "w_buff";
		w_buff.damage_buff = 0;
		w_buff.AddBuff();

		Buff p_buff = Instantiate(buff, transform).GetComponent<Buff>();
		p_buff.id = "p_buff";
		p_buff.armor_buff = 0;
		p_buff.AddBuff();

		Buff b_buff = Instantiate(buff, transform).GetComponent<Buff>();
		b_buff.id = "b_buff";
		b_buff.draw_winner = false;
		b_buff.AddBuff();
	}
}
