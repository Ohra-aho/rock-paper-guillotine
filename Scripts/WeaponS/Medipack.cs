using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medipack : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = -1;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void ApplyBuffs()
    {
        GetComponent<Healing>().Heal();
        GetComponent<BuffController>().Equip();
    }
}
