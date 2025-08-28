using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kilpimuuri : MonoBehaviour
{
    public void DecreaseDamage()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        int amount = RIE.childCount;
        for(int i = 0; i < amount; i++)
        {
            RIE.GetChild(i).GetComponent<Weapon>().damage--;
            if(RIE.GetChild(i).GetComponent<Weapon>().damage < 0)
            {
                RIE.GetChild(i).GetComponent<Weapon>().damage = 0;
            }
        }
    }
}
