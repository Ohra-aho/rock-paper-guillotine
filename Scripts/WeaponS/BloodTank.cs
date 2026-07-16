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
            if (GetComponent<Stacking>().stacks >= 5)
            {
				GetComponent<Stacking>().stacks = 0;
                GetComponent<HealthIncrease>().Increase();
            }
        }
    }
}
