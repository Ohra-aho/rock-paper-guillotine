using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().damage_bonus = -1;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().special_apply = true;
    }

    public void Activate()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Stacking>().DecreaseStacks(1);
            GetComponent<BuffController>().Equip();
            GetComponent<Healing>().Heal();
        }
    }
}
