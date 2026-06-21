using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howler : MonoBehaviour
{
    public void Stitch()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		if(GetComponent<Weapon>().owner.HB.GiveCurrentHealth() < GetComponent<Weapon>().owner.HB.GiveMaxHealth())
		{
			for(int i = 0; i < RIE.transform.childCount; i++)
			{
				if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Onslaught")
				{
					if(RIE.transform.GetChild(i).GetComponent<Stacking>().stacks > 0)
					{
						GetComponent<Healing>().Heal();
					}
					RIE.transform.GetChild(i).GetComponent<Stacking>().DecreaseStacks(1);
					break;
				}
			}
		}
	}

	public void Collapse()
	{
		GetComponent<Weapon>().owner.HB.InstaKill();
	}

	public void Tear()
	{
		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Onslaught")
			{
				RIE.transform.GetChild(i).GetComponent<Stacking>().IncreaseStacks(1);
				break;
			}
		}
	}

	public void Onslaugth()
	{
		if(GetComponent<Stacking>().stacks <= 0)
		{
			GetComponent<Weapon>().type = MainController.Choise.sakset;
		} else
		{
			GetComponent<Weapon>().type = MainController.Choise.voittamaton;
		}
	}
}
