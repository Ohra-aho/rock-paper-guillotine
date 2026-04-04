using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archnode : MonoBehaviour
{
    public void GivePoints()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        Weapon least = null;
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Stacking>())
            {
                if(least == null)
                {
                    least = weapons[i];
                } else if(least.GetComponent<Stacking>().stacks > weapons[i].GetComponent<Stacking>().stacks)
                {
                    least = weapons[i];
                }
            }
        }

        if(least != null)
        {
            least.GetComponent<Stacking>().IncreaseStacks(1);
        }
    }
}
