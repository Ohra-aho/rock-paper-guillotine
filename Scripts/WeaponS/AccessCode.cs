using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCode : MonoBehaviour
{
    public void Equip()
    {
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for(int i = 0; i < RI.childCount; i++)
        {
            RI.GetChild(i).GetComponent<Weapon>().penetrating = true;
        }
    }

    public void UnEquip()
    {
        Transform RI = GameObject.FindGameObjectWithTag("RI").transform;
        for (int i = 0; i < RI.childCount; i++)
        {
            RI.GetChild(i).GetComponent<Weapon>().penetrating = false;
        }
    }
}
