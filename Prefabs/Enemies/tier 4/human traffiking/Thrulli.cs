using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrulli : MonoBehaviour
{
	int uses = 0;
    public void Activate()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GetComponent<Stacking>())
			{
				weapons[i].GetComponent<Stacking>().IncreaseStacks(1);
			}
		}

		int chance = Random.Range(1, 11);
		if(uses < 2 && chance == 1)
		{
			chance = 2;
			uses++;
		}	

		if(chance == 1)
		{
			GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
			GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
			for(int i = 0; i < RIE.transform.childCount; i++)
			{
				RIE.transform.GetChild(i).GetComponent<Weapon>().damage += 2;
			}
			GetComponent<SelfDestruct>().Destruct();
		}
	}

	public void ActivateUnequipped()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GetComponent<Stacking>())
			{
				weapons[i].GetComponent<Stacking>().IncreaseStacks(1);
			}
		}

		int chance = Random.Range(1, 11);
		if(uses < 2 && chance == 1)
		{
			chance = 2;
			uses++;
		}	
		if(chance == 1)
		{
			GetComponent<Weapon>().player_owner.HB.TakeDamage(1);
			GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
			for(int i = 0; i < RIE.transform.childCount; i++)
			{
				RIE.transform.GetChild(i).GetComponent<Weapon>().damage += 2;
			}
			Destroy(gameObject);
		}
	}
}
