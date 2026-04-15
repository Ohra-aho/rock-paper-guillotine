using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public void Bolt()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<EffectDamage>().amount += GetComponent<Stacking>().stacks;
            GetComponent<EffectDamage>().DealDamage(this.GetComponent<Weapon>());
            GetComponent<EffectDamage>().amount -= GetComponent<Stacking>().stacks;
            GetComponent<SelfDestruct>().Destruct();
        }
    }
}
