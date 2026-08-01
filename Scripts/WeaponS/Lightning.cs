using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return !w.name.Contains(GetComponent<Weapon>().name); };
		GetComponent<BuffController>().gain_points = true;
		GetComponent<BuffController>().special = (Weapon w) => { GetComponent<Stacking>().IncreaseStacks(1); };
	}

    public void Bolt()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<EffectDamage>().amount += GetComponent<Stacking>().stacks;
            GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
            GetComponent<EffectDamage>().amount -= GetComponent<Stacking>().stacks;
			GetComponent<Stacking>().stacks = 0;
        }
    }
}
