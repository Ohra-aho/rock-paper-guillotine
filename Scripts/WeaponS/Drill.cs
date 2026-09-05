using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    private void Awake()
	{
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().buff_requirement = (Weapon w) => {return true; };
		GetComponent<BuffController>().special = (Weapon) => { GiveStacks(); };
	}

	public void GiveStacks()
	{
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(TC.player_damage > 0 && TC.player_armor > 0)
		{
			GetComponent<Stacking>().IncreaseStacks(1);
		}
	}

	public void UseStacks()
	{
		if(GetComponent<Stacking>().stacks >= 2)
		{
			GetComponent<Stacking>().DecreaseStacks(2);
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		}
	}
}
