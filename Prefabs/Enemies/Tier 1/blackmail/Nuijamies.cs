using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuijamies : MonoBehaviour
{
    public void Choke()
	{
		GetComponent<Stacking>().DecreaseStacks(1);
		if(GetComponent<Stacking>().stacks == 0)
		{
			GetComponent<Stacking>().stacks = 2;
			GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
		}
	}

	public void DrawDemand()
	{
		GetComponent<EffectDamage>().amount = 2;
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}

	public void WinDemand()
	{
		GetComponent<EffectDamage>().amount = 4;
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}
}
