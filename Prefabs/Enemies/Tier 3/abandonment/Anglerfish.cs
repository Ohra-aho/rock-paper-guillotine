using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfish : MonoBehaviour
{
	public GameObject buff;
	bool used = false;
    public void Breath()
	{
		for(int i = 0; i < 3; i++)
		{
			bool removed = GetComponent<PermanentDebuffer>().RemoveWeaponFromInvetory("Weakness");
			if(removed)
			{
				GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
			}
		}
		/*if(!used)
		{
			List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				Buff new_buff = Instantiate(buff, weapons[i].transform).GetComponent<Buff>();
				new_buff.id = GetComponent<Weapon>().name;
				new_buff.damage_buff = -2;
				new_buff.temporary = true;
				new_buff.until_used = true;
				new_buff.reminder = new_buff.damage_buff+" damage until used.";
				new_buff.AddBuff();
			}
			used = true;
		} */
	}

	public void Weight()
	{
		GetComponent<Stacking>().IncreaseStacks(1);
		GetComponent<WeaponSpawner>().SpawnSpecificWeapon(0);
		if(GetComponent<Stacking>().stacks >= 3)
		{
			GetComponent<WeaponSpawner>().SpawnSpecificWeapon(1);
			GetComponent<Weapon>().owner.HB.InstaKill();
		}
	}

	public void WeightTwo()
	{
		GetComponent<Stacking>().DecreaseStacks(1);
	}
}
