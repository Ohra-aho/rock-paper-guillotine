using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardboard : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().special_apply = true;
    }

    public void AppluBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
