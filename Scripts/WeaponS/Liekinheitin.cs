using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liekinheitin : MonoBehaviour
{
	public void BlazeOpponent()
	{
		if(GetComponent<Stacking>().stacks >= 2)
		{
			GetComponent<Stacking>().DecreaseStacks(2);
			GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
		}
	}
}
