using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realinventory : MonoBehaviour
{
    public GameObject? FindWeapon(string name)
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<Weapon>().name == name)
			{
				return transform.GetChild(i).gameObject;
			}
		}
		return null;
	}
}
