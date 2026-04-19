using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price : MonoBehaviour
{
    public void DealDamage()
    {
        GetComponent<EffectDamage>().amount = GetComponent<Stacking>().stacks;
        GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        GetComponent<SelfDestruct>().Destruct();
    }
}
