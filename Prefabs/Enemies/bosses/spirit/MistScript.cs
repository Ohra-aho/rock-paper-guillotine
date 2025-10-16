using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistScript : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<Mask>(); };
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
    }

    public void TakeDamage()
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() <= 0)
        {
            GetComponent<BuffController>().Equip();
        }
    }
}
