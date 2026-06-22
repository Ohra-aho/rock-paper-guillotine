using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCold : MonoBehaviour
{
	public void Die()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}
}
