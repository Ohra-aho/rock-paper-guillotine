using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public void DecreaseArmor()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        int amount = RIE.childCount;
        for (int i = 0; i < amount; i++)
        {
            RIE.GetChild(i).GetComponent<Weapon>().armor--;
            if (RIE.GetChild(i).GetComponent<Weapon>().armor < 0)
            {
                RIE.GetChild(i).GetComponent<Weapon>().armor = 0;
            }
        }
    }
}
