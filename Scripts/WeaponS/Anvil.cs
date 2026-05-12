using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
	public Buff buff;
    public void IcreaseDamage()
    {
        Weapon weakest = FindWeakestWeapon();
		Buff new_buff = Instantiate(buff, weakest.transform);
		new_buff.id = GetComponent<Weapon>().name;
		new_buff.damage_buff = 1;
		new_buff.AddBuff();
    }

	public Weapon FindWeakestWeapon()
	{
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		if(weapons.Count > 0)
		{
			Weapon weakest = weapons[0];
			for(int i = 0; i < weapons.Count; i++)
			{
				if(weapons[i].name != GetComponent<Weapon>().name)
				{
					weakest = weapons[i];
					break;
				}
			}
			for(int i = 0; i < weapons.Count; i++)
			{
				if(weapons[i].name != GetComponent<Weapon>().name)
				{
					if(weapons[i].GiveEffectiveDamage() < weakest.GiveEffectiveDamage())
					{
						weakest = weapons[i];
					} else if(weapons[i].GiveEffectiveDamage() == weakest.GiveEffectiveDamage())
					{
						if(Random.Range(0, 2) == 0)
						{
							weakest = weapons[i];
						}
					}	
				}
			}
			return weakest;
		}
		return GetComponent<Weapon>();
	}
}
