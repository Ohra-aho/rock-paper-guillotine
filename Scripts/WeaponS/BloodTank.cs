using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTank : MonoBehaviour
{
    int current_health_bonus = 0;
    public void IncreaseStacks()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(current_health_bonus < 15)
        {
            if (GetComponent<Stacking>().stacks > 0 && GetComponent<Stacking>().stacks % 1 == 0)
            {
                current_health_bonus++;
                IncreaseHealth(1, true);
            }
        }
    }

    public void IncreaseHealth(int bonus, bool in_view)
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.IncreaseHealthBar(bonus, in_view);
    }

    public void DecreaseHealth(int bonus, bool in_view)
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.DecreaseHealthBar(bonus, in_view);
    }

    public void Equip()
    {
        IncreaseHealth(current_health_bonus, false);
    }

    public void UnEquip()
    {
        DecreaseHealth(current_health_bonus, false);
    }

    public void LoadHealth()
    {
        current_health_bonus = GetComponent<Stacking>().GiveAmountOfStackDividedBy(3);
    }
}
