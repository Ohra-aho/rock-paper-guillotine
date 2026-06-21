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

	public void Die()
	{
		GameObject.Find("EnemyHealth").GetComponent<HealthBar>().InstaKill();
	}
}
