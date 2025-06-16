using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seteli : MonoBehaviour
{
    //Needs something similar with aarrearkku
    public void Equip()
    {
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for(int i = 0; i < RI.childCount; i++)
        {
            if(RI.GetChild(i).GetComponent<Stacking>())
            {
                RI.GetChild(i).GetComponent<Stacking>().IncreaseStacks(1);
            }
        }
    }

    public void UnEquip()
    {
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for (int i = 0; i < RI.childCount; i++)
        {
            if (RI.GetChild(i).GetComponent<Stacking>())
            {
                RI.GetChild(i).GetComponent<Stacking>().DecreaseStacks(1);
            }
        }
    }
}
