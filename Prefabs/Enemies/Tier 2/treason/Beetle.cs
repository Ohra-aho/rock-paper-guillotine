using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
	public int limit;

	public void Grow()
	{
		List<Weapon> equipped = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		List<GameObject> to_destroy = new List<GameObject>();
		int to_limit = 0;

		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(!equipped.Contains(RI.transform.GetChild(i).GetComponent<Weapon>()))
			{
				if(
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Weakness" || 
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Bleed" || 
					RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison"
				)
				{
					to_destroy.Add(RI.transform.GetChild(i).gameObject);
					to_limit++;
					if(to_limit == limit)
					{
						break;
					}
				}
			}
		}

		for(int i = to_destroy.Count-1; i >= 0; i--)
		{
			Destroy(to_destroy[i]);
		}

		GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
		for(int i = 0; i < RIE.transform.childCount; i++)
		{
			if(RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name)
			{
				RIE.transform.GetChild(i).GetComponent<Weapon>().damage += to_limit;	
			}
		}
	}
}
