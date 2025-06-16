using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handcerchife : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Stacking>().stack_limit = 3;
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().dealDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void IncreaseStack(Weapon weapon)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(GetComponent<Stacking>().stacks == 3)
        {
            GetComponent<EffectDamage>().DealDamage(weapon);
            GetComponent<Stacking>().stacks = 0;
        }
    }
}
