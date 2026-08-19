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

		GetComponent<Weapon>().special_token = () => { return GetComponent<HealthIncrease>().amount; };
		GetComponent<Weapon>().load_special_token = () =>
		{
			GetComponent<HealthIncrease>().amount = GetComponent<Weapon>().token;
			GetComponent<Weapon>().description 
				= "+"+GetComponent<HealthIncrease>().amount+" HP. If you don't heal during a fight, you get -1 HP at the end of it. Whenever unequipped, -1 HP.";
		};
	}

	public void RotAway()
    {
		if(!healed)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.DecreaseHealthBar(1, true);
        	GetComponent<HealthIncrease>().amount--;
			GetComponent<Weapon>().description 
				= "+"+GetComponent<HealthIncrease>().amount+" HP. If you don't heal during a fight, you get -1 HP at the end of it. Whenever unequipped, -1 HP.";
		}
    }

	public void Use()
	{
		used = true;
		healed = false;
	}

	public void Unequip()
	{
		GetComponent<HealthIncrease>().DecreaseSetAmount(1);	
	}
}
