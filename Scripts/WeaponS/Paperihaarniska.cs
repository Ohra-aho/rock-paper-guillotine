using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperihaarniska : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Stacking>().stack_limit = 4;
    }

    public void IncreaseStack()
    {
        if(GetComponent<Weapon>().armor > 0 && GetComponent<Weapon>().GiveEffectiveArmor() > 0)
        {
            GetComponent<Stacking>().IncreaseStacks(1);
            CalculateArmor();
        } else
        {
            GetComponent<SelfDestruct>().Destruct();
        }
    }

    public void CalculateArmor()
    {
        GetComponent<Weapon>().armor = 4 - GetComponent<Stacking>().stacks;
    }
}
