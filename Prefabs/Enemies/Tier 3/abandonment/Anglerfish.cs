using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfish : MonoBehaviour
{
	public GameObject buff;
    public void Breath()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			Buff new_buff = Instantiate(buff, weapons[i].transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.damage_buff = -2;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.AddBuff();
		}
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
