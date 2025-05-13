using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyssy : MonoBehaviour
{
    public void IncreaseStack()
    {
        if(GetComponent<Weapon>().stacks <= 6)
        {
            GetComponent<Weapon>().stacks++;
            GetComponent<Weapon>().damage = 6 - GetComponent<Weapon>().stacks;
            if (GetComponent<Weapon>().damage < 0)
            {
                GetComponent<Weapon>().damage = 0;
            }
            if(GetComponent<Weapon>().damage == 0)
            {
                GetComponent<SelfDestruct>().Destruct();
            }
        }
    }
}
