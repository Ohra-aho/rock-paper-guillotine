using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappolista : MonoBehaviour
{
    public void IncreaseStacks()
    {
        CalculateDamage();
    }

    public void CalculateDamage()
    {
        int amount = 0;
        GetComponent<Weapon>().damage -= GetComponent<Stacking>().GiveAmountOfStackDividedBy(1);
        GetComponent<Stacking>().IncreaseStacks(1);
        amount = GetComponent<Stacking>().GiveAmountOfStackDividedBy(1);
        GetComponent<Weapon>().damage += amount;
    }

    public void RemovePrevBuff()
    {
        GetComponent<Weapon>().damage -= GetComponent<Stacking>().GiveAmountOfStackDividedBy(1);
    }

    public void AddBuff()
    {
        GetComponent<Weapon>().damage += GetComponent<Stacking>().GiveAmountOfStackDividedBy(1); ;
    }
}
