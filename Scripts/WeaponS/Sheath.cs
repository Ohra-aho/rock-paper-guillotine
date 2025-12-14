using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheath : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.type == MainController.Choise.sakset; };
        GetComponent<BuffController>().armor_bonus = 2;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().special_apply = true;
    }

    public void AppluBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
