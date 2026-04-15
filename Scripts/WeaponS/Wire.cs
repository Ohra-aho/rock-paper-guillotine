using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().heal = true;
        GetComponent<BuffController>().special = GiveAPoint;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void GiveAPoint(Weapon w)
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        Weapon least = null;

        for(int i = 0; i < weapons.Count; i++)
        {
            if(least == null && weapons[i].GetComponent<Stacking>())
            {
                least = weapons[i];
            } else if(weapons[i].GetComponent<Stacking>())
            {
                if(weapons[i].GetComponent<Stacking>().stacks < least.GetComponent<Stacking>().stacks)
                {
                    least = weapons[i];
                }
            }
        }

        least.GetComponent<Stacking>().IncreaseStacks(1);
    }
}
