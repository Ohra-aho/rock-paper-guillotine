using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB_Reload : MonoBehaviour
{
    public void Reload()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Presicion shot")
            {
                RIE.transform.GetChild(i).GetComponent<Stacking>().IncreaseStacks(1);
                break;
            }
        }
    }
}
