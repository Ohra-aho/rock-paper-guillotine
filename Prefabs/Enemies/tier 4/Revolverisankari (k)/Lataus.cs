using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lataus : MonoBehaviour
{
    public void Reload()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Revolveri" || RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Revolver")
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage = 6;
            }
        }
    }
}
