using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incorporeal : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
    }

    public void ApplyBuff()
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() <= 0)
        {
            //Debug.Log("Que");
            GetComponent<BuffController>().Equip();
        }
    }
}
