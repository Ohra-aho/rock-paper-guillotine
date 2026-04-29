using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damnation : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == "Annahilation"; };
        GetComponent<BuffController>().until_used = true;
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuffs()
    {
        GetComponent<BuffController>().Equip();
    }

    public void DebuffOpposingWeapon()
    {
        Buff new_buff = Instantiate(GetComponent<BuffController>().buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
        new_buff.type_change = MainController.Choise.hyödytön;
        new_buff.until_used = true;
        new_buff.used = false;
        new_buff.AddBuff();
    }
}
