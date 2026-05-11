using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public GameObject buff;

    public void ApplyBuff()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		Weapon weakest =  FindWeakestWeapon(weapons);

        GameObject new_buff = Instantiate(buff, weakest.transform);
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().damage_buff = 1;
        new_buff.GetComponent<Buff>().temporary = true;
        new_buff.GetComponent<Buff>().timer = 1000;
        new_buff.GetComponent<Buff>().AddBuff();
    }

	private Weapon FindWeakestWeapon(List<Weapon> weapons)
	{
		Weapon weakest = weapons[0];
		for(int i = 1; i < weapons.Count; i++)
		{
			if(weakest.GiveEffectiveDamage() > weapons[i].GiveEffectiveDamage())
			{
				weakest = weapons[i];
			}
		}
		return weakest;
	}
}
