using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    public void DealDamage()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<Stacking>().DecreaseStacks(1);
        }
    }

    public void BuffWeapons()
    {
        if (GetComponent<Stacking>().stacks > 0)
        {
            GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
            for (int i = 0; i < RIE.transform.childCount; i++)
            {
                if(RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name)
                {
                    RIE.transform.GetChild(i).GetComponent<Weapon>().damage++;
                }
            }
            GetComponent<Stacking>().DecreaseStacks(1);
        }
    }
}
