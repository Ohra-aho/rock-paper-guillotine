using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relentless : MonoBehaviour
{
	public void DealDamage()
	{
		GameObject.Find("EnemyHealth").GetComponent<HealthBar>().TakeDamage(1);
	}
}
