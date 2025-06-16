using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stacking : MonoBehaviour
{
    public int stacks;
    public int stack_limit;
    public UnityEvent LoadFunction; //Used during loading to do necessary calculations

    public void IncreaseStacks(int amount)
    {
        if (stack_limit > 0)
        {
            if(stacks < stack_limit)
            {
                stacks += amount;
            }
            /*if (stacks > stack_limit)
            {
                stacks = stack_limit;
            }*/
        } else
        {
            stacks += amount;
        }

    }

    public void DecreaseStacks(int amount)
    {
        stacks -= amount;
        if(stacks < 0)
        {
            stacks = 0;
        }
    }

    public int GiveAmountOfStackDividedBy(int x)
    {
        if (GetComponent<Stacking>().stacks >= x)
        {
            return stacks / x;
        }
        return 0;
    }
}
