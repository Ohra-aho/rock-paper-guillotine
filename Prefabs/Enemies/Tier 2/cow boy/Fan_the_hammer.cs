using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_the_hammer : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != "Reload"; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void ApplyBuff()
    {
        //Debug.Log("Que");
        GetComponent<BuffController>().Equip(); //.AddBuffs();
    }
}
