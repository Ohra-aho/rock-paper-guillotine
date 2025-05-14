using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handcerchife : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().dealDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void IncreaseStack(Weapon weapon)
    {
        GetComponent<Weapon>().stacks++;
        if(GetComponent<Weapon>().stacks == 3)
        {
            weapon.EffectDamage(1);
            GetComponent<Weapon>().stacks = 0;
        }
    }
}
