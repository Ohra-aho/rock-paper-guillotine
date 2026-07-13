using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
	private bool used = false;
	private bool healed = false;

	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().heal = true;
		GetComponent<BuffController>().special = (Weapon w) => { healed = true; }; 
	}

	public void RotAway()
    {
		if(!healed)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.DecreaseHealthBar(1, true);
        	GetComponent<HealthIncrease>().amount--;	
		}
    }

	public void Use()
	{
		used = true;
		healed = false;
	}

	public void Unequip()
	{
		if(used)
		{
			used = false;
			GetComponent<HealthIncrease>().DecreaseSetAmount(1);
		}
	}
}
