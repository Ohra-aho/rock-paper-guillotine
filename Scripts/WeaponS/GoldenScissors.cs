using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenScissors : MonoBehaviour
{
    public void GivePoints()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GetComponent<Stacking>())
			{
				if(weapons[i].GetComponent<Stacking>().stacks == 0)
				{
					weapons[i].GetComponent<Stacking>().IncreaseStacks(1);
				}
			}
		}
	}
}
