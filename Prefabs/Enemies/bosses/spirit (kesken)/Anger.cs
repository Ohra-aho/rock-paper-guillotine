using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().set_a_to_zero = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
    }

    public void WearMask()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
       /* for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<BuffController>().Unequip();
        }*/
        GetComponent<BuffController>().Equip();
    }
}
