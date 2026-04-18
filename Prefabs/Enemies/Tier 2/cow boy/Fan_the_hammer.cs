using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_the_hammer : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().damage_bonus = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void ApplyBuff()
    {
        GetComponent<BuffController>().Equip();
    }
}
