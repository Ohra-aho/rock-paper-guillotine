using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raivo : MonoBehaviour
{
	int health_taken = 0;
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().armor_bonus = 1;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}
	public void Corrupt()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}

	public void Radiance()
	{
		GetComponent<EffectDamage>().amount = GetComponent<Stacking>().stacks;
		GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}

	public void Undo()
	{
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth() > 1)
		{
			GetComponent<PermanentDebuffer>().DecreaseOpposingHealth(1);
			health_taken++;
		}
	}

	public void ResetUndo()
	{
		GetComponent<PermanentDebuffer>().IncreaseOpposingHealth(health_taken);
	}
	
}
