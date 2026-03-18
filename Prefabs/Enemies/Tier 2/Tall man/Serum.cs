using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serum : MonoBehaviour
{
    public void Heal()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Healing>().Heal();
            GetComponent<Stacking>().DecreaseStacks(1);
        }
        GetComponent<Weapon>().owner.off_balance_triggered = false;
        GetComponent<Weapon>().owner.Balance();
    }
}
