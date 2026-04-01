using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappolista : MonoBehaviour
{
    bool kill = false;

    public void Kill()
    {
        kill = true;
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void EndOfFight()
    {
        if(!kill)
        {
            RemovePrevBuff();
            GetComponent<Stacking>().stacks = 0;
            AddBuff();
        }
        kill = false;
    }

    public void RemovePrevBuff()
    {
        GetComponent<Weapon>().damage -= GetComponent<Stacking>().stacks;
    }

    public void AddBuff()
    {
        GetComponent<Weapon>().damage += GetComponent<Stacking>().stacks;
    }
}
