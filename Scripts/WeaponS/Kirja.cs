using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{

    public void IncreaseStacks()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        GetComponent<Weapon>().damage = 1 + GetComponent<Stacking>().GiveAmountOfStackDividedBy(2);
    }

}
