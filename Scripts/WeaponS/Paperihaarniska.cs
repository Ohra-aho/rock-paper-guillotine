using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperihaarniska : MonoBehaviour
{
    public void IncreaseStack()
    {
        if(GetComponent<Weapon>().armor > 0 && GetComponent<Weapon>().GiveEffectiveArmor() > 0)
        {
            GetComponent<Stacking>().DecreaseStacks(1);
        } else
        {
            GetComponent<SelfDestruct>().Destruct();
        }
    }

    public void CalculateArmor()
    {
        GetComponent<Weapon>().armor = GetComponent<Stacking>().stacks;
    }
}
