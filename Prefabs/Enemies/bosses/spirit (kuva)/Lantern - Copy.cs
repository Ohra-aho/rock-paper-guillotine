using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public void DealDamage()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(GetComponent<Stacking>().stacks ==  3)
        {
            GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<Stacking>().stacks = 0;
        }
    }

    public void TakesDamage()
    {
        GetComponent<Stacking>().DecreaseStacks(1);
    }

}
