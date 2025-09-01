using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySign : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
        GetComponent<BuffController>().special_apply = true;
    }

    public void ApplyBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
