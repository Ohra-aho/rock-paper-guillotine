using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viikate : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon != this; };
        GetComponent<BuffController>().onDestruction = true;
    }

    public void IncreaseStack(Weapon weapon)
    {
        Debug.Log("Stacking");
        GetComponent<Stacking>().IncreaseStacks(2);
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        GetComponent<Weapon>().damage = 1 + GetComponent<Stacking>().stacks;
    }
}
