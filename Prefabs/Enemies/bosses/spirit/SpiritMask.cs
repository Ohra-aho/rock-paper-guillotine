using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMask : MonoBehaviour
{
    public void WearMask()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<SpiritMask>())
            {
                RIE.transform.GetChild(i).GetComponent<BuffController>().Unequip();
                if(RIE.transform.GetChild(i).GetComponent<Fear>())
                {
                    RIE.transform.GetChild(i).GetComponent<Fear>().RemoveDebuffs();
                }
            }
        }
        GetComponent<BuffController>().Equip();
    }
}
