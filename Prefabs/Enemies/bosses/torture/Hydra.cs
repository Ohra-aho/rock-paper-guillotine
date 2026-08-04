using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : MonoBehaviour
{
    public GameObject buff;

	public void Crush()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name)) 
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.destructive = true;
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "After use, self-destructs.";
			new_buff.AddBuff();
		}
	}

	public void Hang()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { GetComponent<EffectDamage>().DealSetDamage(1); };
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "After use, deals 1 damage to you.";
			new_buff.AddBuff();
		}
	}

	public void Impale()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { GetComponent<Healing>().Heal(); };
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "After use, enemy heals 1.";
			new_buff.AddBuff();	
		}
	}

	public void Rack()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { w.damage--; if(w.damage < 0) w.damage = 0; };
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "After use, -1 damage.";
			new_buff.AddBuff();	
		}
	}

	public void Skin()
	{
		if(!GetComponent<Weapon>().opponent.FindCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.endPhase = true;
			new_buff.special = (Weapon w) => { GetComponent<WeaponSpawner>().SpawnOnlyWeapon(); };
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "After use, you get a Bleed.";
			new_buff.AddBuff();	
		}
	}
}
