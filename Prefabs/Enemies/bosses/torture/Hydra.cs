using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : MonoBehaviour
{
    public GameObject buff;

	public void Crush()
	{
		Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.destructive = true;
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}

	public void Hang()
	{
		Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.endPhase = true;
		new_buff.special = (Weapon w) => { GetComponent<EffectDamage>().DealSetDamage(1); };
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}

	public void Impale()
	{
		Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.endPhase = true;
		new_buff.special = (Weapon w) => { GetComponent<Healing>().Heal(); };
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}

	public void Rack()
	{
		Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.endPhase = true;
		new_buff.special = (Weapon w) => { w.damage--; if(w.damage < 0) w.damage = 0; };
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}

	public void Skin()
	{
		Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.endPhase = true;
		new_buff.special = (Weapon w) => { GetComponent<WeaponSpawner>().SpawnOnlyWeapon(); };
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}
}
