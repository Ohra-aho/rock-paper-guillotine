using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB_Reload : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().damage_bonus = 1;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().special_apply = true;
    }

    public void Reload()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Presicion shot")
            {
                RIE.transform.GetChild(i).GetComponent<Stacking>().IncreaseStacks(2);
                break;
            }
        }
    }
}
