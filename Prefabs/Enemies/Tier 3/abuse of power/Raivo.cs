using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raivo : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 3;
			GetComponent<BuffController>().special_apply = true;
		}
	}
	public void Corrupt()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}

	public void Radiance()
	{
		GetComponent<Stacking>().IncreaseStacks(1);
		GetComponent<EffectDamage>().amount = GetComponent<Stacking>().stacks;
		GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}
	
}
