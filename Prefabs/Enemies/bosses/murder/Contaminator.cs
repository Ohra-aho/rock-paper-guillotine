using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaminator : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().damage_bonus = 1;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Die()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}


	public void Spawn()
	{
		if(GetComponent<Stacking>().stacks >= 3)
		{
			GetComponent<EffectDamage>().SelfDamage(GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise);
			GetComponent<EffectDamage>().DealDamage(GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise);
			GetComponent<SelfDestruct>().Destruct();
		}
	}


	public void Spawnunequipped()
	{
		if(GetComponent<Stacking>().stacks >= 3)
		{
        	GameObject.Find("EnemyHealth").GetComponent<HealthBar>().TakeDamage(GetComponent<EffectDamage>().amount);
        	GameObject.Find("PlayerHealth").GetComponent<HealthBar>().TakeDamage(GetComponent<EffectDamage>().amount);
			GetComponent<Weapon>().CheckUp();
			Destroy(gameObject);
		}
	}
}
