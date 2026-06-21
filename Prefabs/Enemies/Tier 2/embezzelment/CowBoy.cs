using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBoy : MonoBehaviour
{
    public void Harvest()
	{
		int amount = GameObject.Find("PlayerHealth").GetComponent<HealthBar>().GiveMaxHealth();
		amount -= 3;
		if(amount > 0)
		{
			GetComponent<Healing>().amount = amount;
			GetComponent<Healing>().Heal();
		}
	}
}
