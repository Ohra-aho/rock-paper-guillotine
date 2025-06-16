using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kilpimuuri : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Remove;
        GetComponent<BuffController>().win = true;
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().armor_bonus = GetComponent<Weapon>().armor;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name != GetComponent<Weapon>().name; };
    }

    public void Remove(Weapon weapon)
    {
        GetComponent<BuffController>().Unequip();
    }

    public void Activate()
    {
        GetComponent<BuffController>().Equip();
    }

    public void IncreaseStack()
    {
        if (GetComponent<Stacking>().stacks <= 4)
        {
            GetComponent<Stacking>().IncreaseStacks(1);
            GetComponent<Weapon>().armor = 4 - GetComponent<Stacking>().stacks;
            if (GetComponent<Weapon>().armor < 0)
            {
                GetComponent<Weapon>().armor = 0;
            }
        }
    }


}
