using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacelessS : MonoBehaviour
{
	int form = 0;
	void Awake()
	{
		form = Random.Range(1, 4);
		form = 1;
		switch(form)
		{
			case 1:
				GetComponent<Weapon>().description = "After use, removes 1 debuff from your inventory and heals 1 if debuff was removed.";
				break;
			case 2:
				GetComponent<Weapon>().description = "After use, removes 1 debuff from your inventory and heals 1 if debuff was removed.";
				break;
			case 3:
				GetComponent<Weapon>().description = "After use, removes 1 debuff from your inventory and heals 1 if debuff was removed.";
				break;
		}
	}

	public void RemoveDebuffs()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(
				RI.transform.GetComponent<Weapon>().name == "Poison" || 
				RI.transform.GetComponent<Weapon>().name == "Bleed" || 
				RI.transform.GetComponent<Weapon>().name == "Weakness" ||
				RI.transform.GetComponent<Weapon>().name == "Dismemberment"
			)
			{
				Destroy(RI.transform.gameObject);
				GetComponent<Healing>().Heal();
				break;
			}
		}
	}
}
