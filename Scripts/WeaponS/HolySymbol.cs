using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySymbol : MonoBehaviour
{
  
    public void Worship()
    {
        GetComponent<Stacking>().IncreaseStacks(3);
    }

    public void Miracle()
    {
        if (GetComponent<Stacking>().stacks >= 3)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<WeaponSpawner>().SpawnRandomWeapon();
        }
    }
}
