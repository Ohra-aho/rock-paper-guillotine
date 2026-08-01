using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puolustusmanifesti : MonoBehaviour
{
    int armor_found = 0;
	bool first_trigger = true;
	public void DealDamage()
	{
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(!first_trigger)
		{
			if(TC.GiveEffectivePlayerDamage() == 0 && TC.GiveEffectiveEnemyDamage() == 0)
			{
				GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
			}	
		}
		first_trigger = false;
	}

	public void ResetFirsttrigger()
	{
		first_trigger = true;
	}

    public void CalculateDamage()
    {
        int damage = 0;

        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            damage += weapons[i].GiveEffectiveArmor();
        }

        if(armor_found < damage)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
        if(damage < armor_found)
        {
            GetComponent<Weapon>().damage -= armor_found;
            armor_found = damage;
            GetComponent<Weapon>().damage += armor_found;
        }
    }
}
