using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
	bool used = false;
	public void Enable()
	{
		used = true;
	}
	public void Use()
	{
		if(used)
		{
			TableController TC = GameObject.Find("Table").GetComponent<TableController>();
			TC.enemy_damage = TC.enemy_damage * 2;
			TC.enemy_direct_damage = TC.enemy_direct_damage * 2;	
		}
		used = false;
	}
}
