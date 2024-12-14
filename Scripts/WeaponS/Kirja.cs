using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirja : MonoBehaviour
{
    private int stacks = 0;

    public void IncreaseStacks()
    {
        bool? victory = GetComponent<Weapon>().GetVictory();
        if (victory != null && victory == true) stacks++;
    }
    
}
