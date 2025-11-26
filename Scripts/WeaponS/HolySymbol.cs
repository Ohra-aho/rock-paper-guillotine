using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySymbol : MonoBehaviour
{
    public void Activate()
    {
        if (!GetComponent<Stacking>().IsAtLimit()) GetComponent<Stacking>().IncreaseStacks(5);
        int stacks = GetComponent<Stacking>().stacks;
        if(stacks == 3)
        {
            GetComponent<Weapon>().damage++;
        }

        if(stacks == 5)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<HealthIncrease>().amount++;
            GetComponent<HealthIncrease>().Increase();
        }

        if(stacks == 10)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<Healing>().amount++;
            GetComponent<Weapon>().endPhase.AddListener(GetComponent<Healing>().Heal);
            GetComponent<HealthIncrease>().Increase();
            GetComponent<HealthIncrease>().amount++;
        }
    }

    public void LoadEvent()
    {
        int stacks = GetComponent<Stacking>().stacks;
        if (stacks >= 3)
        {
            GetComponent<Weapon>().damage++;
        }

        if (stacks >= 6)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<HealthIncrease>().amount++;
        }

        if (stacks == 10)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<HealthIncrease>().amount++;
            GetComponent<Healing>().amount++;
            GetComponent<Weapon>().endPhase.AddListener(GetComponent<Healing>().Heal);
        }
    }
}
