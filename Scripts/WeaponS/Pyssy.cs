using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyssy : MonoBehaviour
{
    public void DealDamage()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<Stacking>().DecreaseStacks(1);
        if (GetComponent<Weapon>().player)
        {
            if (GetComponent<Stacking>().stacks <= 0)
            {
                GetComponent<SelfDestruct>().Destruct();
            }
        }
    }
}
