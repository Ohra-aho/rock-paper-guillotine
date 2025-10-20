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
        GetComponent<Weapon>().damage -= GetComponent<Stacking>().stacks;
        GetComponent<Stacking>().IncreaseStacks(amount);
        GetComponent<Weapon>().damage += GetComponent<Stacking>().stacks;
    }
}
