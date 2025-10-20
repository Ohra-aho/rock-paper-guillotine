using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyssy : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Stacking>().stack_limit = 6;
    }
    public void IncreaseStack()
    {
        if (GetComponent<Weapon>().player)
        {
            if (GetComponent<Weapon>().damage <= 1)
            {
                GetComponent<SelfDestruct>().Destruct();
            }
        }
        GetComponent<Stacking>().IncreaseStacks(1);
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        GetComponent<Weapon>().damage = GetComponent<Weapon>().damage / 2;
        
    }
}
