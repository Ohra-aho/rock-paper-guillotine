using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stacking : MonoBehaviour
{
    public int stacks;
    public int stack_limit;
    public UnityEvent LoadFunction; //Used during loading to do necessary calculations

    //Functions to smooth out buffing
    public UnityEvent before_stacking;
    public UnityEvent after_stacking;

    public void IncreaseStacks(int amount)
    {
        if (stack_limit > 0)
        {
            if(stacks < stack_limit)
            {
                if (before_stacking != null) before_stacking.Invoke();
                stacks += amount;
                GameObject RLC = GameObject.Find("EventSystem");
                RLC.GetComponent<RLController>().hoard_counter++;
                RLC.GetComponent<RLController>().CheckForHoarder();
            }
            if (stacks > stack_limit)
            {
                stacks = stack_limit;
            }
            if (after_stacking != null) after_stacking.Invoke();
        }
        else
        {
            if (before_stacking != null) before_stacking.Invoke();
            stacks += amount;
            if (after_stacking != null) after_stacking.Invoke();
            GameObject RLC = GameObject.Find("EventSystem");
            RLC.GetComponent<RLController>().hoard_counter++;
            RLC.GetComponent<RLController>().CheckForHoarder();
        }

    }

    public void DecreaseStacks(int amount)
    {
        if (after_stacking != null) after_stacking.Invoke();
        stacks -= amount;
        if(stacks < 0)
        {
            stacks = 0;
        }
        if (after_stacking != null) after_stacking.Invoke();
    }

    public int GiveAmountOfStackDividedBy(int x)
    {
        if (GetComponent<Stacking>().stacks >= x)
        {
            return stacks / x;
        }
        return 0;
    }

    public bool IsAtLimit()
    {
        return stacks == stack_limit;
    }
}
