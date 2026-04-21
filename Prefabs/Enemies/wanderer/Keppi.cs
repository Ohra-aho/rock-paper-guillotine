using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keppi : MonoBehaviour
{
    public void Missed()
    {
        GameObject.Find("Wanderer(Clone)").GetComponent<Wanderer>().stick_missed = true;
    }

    public void DebuffOpposingWeapon()
    {
        GetComponent<Weapon>().opponent.damage--;
        if(GetComponent<Weapon>().opponent.damage < 0)
        {
            GetComponent<Weapon>().opponent.damage = 0;
        }
    }
}
