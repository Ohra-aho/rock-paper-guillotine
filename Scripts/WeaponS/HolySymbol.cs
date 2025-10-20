using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySymbol : MonoBehaviour
{
    public void Activate()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        int stacks = GetComponent<Stacking>().stacks;
        if(stacks == 3)
        {
            GetComponent<Weapon>().damage++;
        }

        if(stacks == 6)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<HealthIncrease>().amount++;
            GetComponent<HealthIncrease>().Increase();
        }

        if(stacks == 10)
        {
            GetComponent<Weapon>().damage++;
            GetComponent<HealthIncrease>().amount++;
            GetComponent<Healing>().amount++;
            GetComponent<Weapon>().endPhase.AddListener(GetComponent<Healing>().Heal);
            GetComponent<HealthIncrease>().Increase();
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
