using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damnation : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == "Flames"; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
