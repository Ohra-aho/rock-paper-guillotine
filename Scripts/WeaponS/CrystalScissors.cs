using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScissors : MonoBehaviour
{
	public GameObject buff;

	void Awake()
	{
		Buff own_buff = Instantiate(buff, transform).GetComponent<Buff>();
		own_buff.damage_buff = GetComponent<Stacking>().stacks;
		own_buff.id = GetComponent<Weapon>().name;
	}

	public void HalfDamage()
    {

		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Stacking>().DecreaseStacks(1);
			//GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
			if(GetComponent<Stacking>().stacks == 0)
			{
				GetComponent<SelfDestruct>().Destruct();
			}
		}
    }

	public void CalculateDamage()
	{
		GameObject own_buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		if(own_buff != null)
		{
			own_buff.GetComponent<Buff>().damage_buff = GetComponent<Stacking>().stacks;	
		} else
		{
			Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
			new_buff.damage_buff = GetComponent<Stacking>().stacks;
			new_buff.id = GetComponent<Weapon>().name;
		}
	}
}
