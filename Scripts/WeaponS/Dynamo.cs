using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamo : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = GainPoint;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().deal_effect_damage = true;
    }

    public void UseStacks()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            int heal = GetComponent<Stacking>().stacks;
            GetComponent<Healing>().Heal();
            GetComponent<Stacking>().DecreaseStacks(1);
        }
    }

    public void GainPoint(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }
}
