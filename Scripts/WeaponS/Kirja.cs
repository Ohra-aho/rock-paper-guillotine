using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{

    public void IncreaseStacks()
    {
        GetComponent<Weapon>().stacks++;
        if (GetComponent<Weapon>().stacks >= 2)
        {
            GetComponent<Weapon>().damage = 1 + GetComponent<Weapon>().stacks / 2;
        }
    }
    
}
