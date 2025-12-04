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
        int heal = GetComponent<Stacking>().stacks / 3;
        GetComponent<Healing>().amount = heal;
        GetComponent<Healing>().Heal();
        GetComponent<Stacking>().stacks = GetComponent<Stacking>().stacks % 3;
    }

    public void GainPoint(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }
}
