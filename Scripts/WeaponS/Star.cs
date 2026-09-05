using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    int previous_HP_gap = 0;

    public void Shine()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Stacking>().DecreaseStacks(1);
			List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				if(weapons[i] != GetComponent<Weapon>() && weapons[i].GetComponent<Stacking>())
				{
					weapons[i].GetComponent<Stacking>().IncreaseStacks(1);
				}
			}
		}
		if(GetComponent<Stacking>().stacks == 0)
		{
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
			GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
			GetComponent<SelfDestruct>().Destruct();
		}
	}
}
