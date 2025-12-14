using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = Stacking;
        GetComponent<BuffController>().heal = true;
    }

    public void Stacking(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void DealDamage()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Stacking>().DecreaseStacks(1);
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
