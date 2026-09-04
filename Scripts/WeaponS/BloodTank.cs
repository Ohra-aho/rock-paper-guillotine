using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTank : MonoBehaviour
{
    int current_health_bonus = 0;

	private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().deal_effect_damage = true;
		GetComponent<BuffController>().special = (Weapon w) => { 
			if(current_health_bonus < 3)
			{
				current_health_bonus++;
				GetComponent<HealthIncrease>().GiveSetTemporaryHealth(1);	
			}
		};
	}

	public void ResetHealthBonus()
	{
		current_health_bonus = 0;
	}
}
