using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viikate : MonoBehaviour
{
    public int amount = 1;
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon != this; };
        GetComponent<BuffController>().onDestruction = true;
    }

    public void IncreaseStack(Weapon weapon)
    {
        GetComponent<Stacking>().IncreaseStacks(amount);
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        GetComponent<Weapon>().damage = 1 + GetComponent<Stacking>().stacks;
    }
}
