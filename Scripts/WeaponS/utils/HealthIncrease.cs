using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    public int amount;
    public bool in_view;

	MainController MC;
	TableController TC;

	void Awake()
	{
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		TC = GameObject.Find("Table").GetComponent<TableController>();
	}

	public void Increase()
    {
		if(MC.game_state != MainController.State.in_battle)
		{
			HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        	HB.IncreaseHealthBar(amount, in_view);	
		} else
		{
			TC.health_increase += amount;
		}
    }

    public void Decrease()
    {
		if(MC.game_state != MainController.State.in_battle)
		{
			HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
			HB.DecreaseHealthBar(amount, in_view);
		} else
		{
			TC.health_decrease += amount;
		}
    }

    public void IncreaseSetAmount(int amount)
    {
		if(MC.game_state != MainController.State.in_battle)
		{
			HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        	HB.IncreaseHealthBar(amount, in_view);
		} else
		{
			TC.health_increase += amount;
		}
        
    }

    public void DecreaseSetAmount(int amount)
    {
        if(MC.game_state != MainController.State.in_battle)
		{
			HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
			HB.DecreaseHealthBar(amount, in_view);
		} else
		{
			TC.health_decrease += amount;
		}
    }

	public void RemoveTemporaryHealth()
	{
		HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.RemoveTemporaryHealth(amount, in_view);
	}

	public void GiveTemporaryHealth()
	{
		HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.GiveTemporaryHealth(amount, in_view);
	}

	public void GiveSetTemporaryHealth(int amount)
	{
		HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
		HB.GiveTemporaryHealth(amount, in_view);
	}

	public void ForceHealthIncrease()
	{
		HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
		HB.IncreaseHealthBar(amount, in_view);	
	}
}
