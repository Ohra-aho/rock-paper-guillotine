using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decreasing : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Weapon>().endPhase.AddListener(Decrese);
    }
    public void Decrese()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name != "Reload")
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage--;
            }
        }
    }
}
