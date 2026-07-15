using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Activate;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }


    public void Activate(Weapon w)
    {
		List<Weapon> weapons = w.player_owner.GetWeapons();
		List<Weapon> possible_weapons = new List<Weapon>();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GetComponent<Stacking>())
			{
				possible_weapons.Add(weapons[i]);
			}
		}
		if(possible_weapons.Count > 0) possible_weapons[Random.Range(0, possible_weapons.Count)].GetComponent<Stacking>().IncreaseStacks(1);
    }
}
