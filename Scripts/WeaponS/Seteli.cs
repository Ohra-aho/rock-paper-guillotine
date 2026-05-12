using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seteli : MonoBehaviour
{
    public void GivePoint()
	{
		List<Weapon> weapons =  GetComponent<Weapon>().player_owner.GetWeapons();
		List<Weapon> possible_weapons = new List<Weapon>();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GetComponent<Stacking>())
			{
				possible_weapons.Add(weapons[i]);
			}
		}
		int index = Random.Range(0, possible_weapons.Count);
		possible_weapons[index].GetComponent<Stacking>().IncreaseStacks(1);
	}
}
