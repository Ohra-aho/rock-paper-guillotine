using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperihaarniska : MonoBehaviour
{
    public void IncreaseStack()
    {
        if(GetComponent<Weapon>().armor > 0)
        {
            GetComponent<Weapon>().stacks++;
            GetComponent<Weapon>().armor = 4 - GetComponent<Weapon>().stacks;
        } else
        {
            GetComponent<SelfDestruct>().Destruct();
        }
    }
}
