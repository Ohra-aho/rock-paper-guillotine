using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juuret : MonoBehaviour
{
    public void Empower()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage += 1;
            }
        }
    }
}
