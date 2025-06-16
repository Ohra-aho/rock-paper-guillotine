using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myrkky : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStacks;
        GetComponent<BuffController>().heal = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name == "Tee"; };
    }

    public void IncreaseStacks(Weapon weapon)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void PoisonDamage()
    {
        GetComponent<Weapon>().EffectDamage(GetComponent<Stacking>().stacks);
    }
}
