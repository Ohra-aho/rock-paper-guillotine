using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public void GivePoints()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Stacking>().DecreaseStacks(1);

            List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
            List<Weapon> possible_weapons = new List<Weapon>();
            for(int i = 0; i < weapons.Count; i++)
            {
                if(weapons[i].GetComponent<Stacking>() && weapons[i].GetComponent<Weapon>().name != GetComponent<Weapon>().name)
                {
                    possible_weapons.Add(weapons[i]);
                }
            }

			if(possible_weapons.Count > 0)
			{
				int index = Random.Range(0, possible_weapons.Count);
				possible_weapons[index].GetComponent<Stacking>().IncreaseStacks(2);
			}
        }
    }
}
