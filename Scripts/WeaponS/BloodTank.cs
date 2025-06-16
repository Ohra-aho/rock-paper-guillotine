using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTank : MonoBehaviour
{
    int current_health_bonus = 0;
    public void IncreaseStacks()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(GetComponent<Stacking>().stacks > 0 && GetComponent<Stacking>().stacks % 1 == 0)
        {
            current_health_bonus++;
            IncreaseHealth(1);
        }
    } 

    public void IncreaseHealth(int bonus)
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.IncreaseHealthBar(bonus);
    }

    public void DecreaseHealth(int bonus)
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.DecreaseHealthBar(bonus);
    }

    public void Equip()
    {
        IncreaseHealth(current_health_bonus);
    }

    public void UnEquip()
    {
        DecreaseHealth(current_health_bonus);
    }

    public void LoadHealth()
    {
        current_health_bonus = GetComponent<Stacking>().GiveAmountOfStackDividedBy(3);
    }
}
