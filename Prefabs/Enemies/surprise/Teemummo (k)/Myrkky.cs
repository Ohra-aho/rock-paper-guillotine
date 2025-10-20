using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myrkky : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStacks;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.name != GetComponent<Weapon>().name; };
    }

    public void IncreaseStacks(Weapon weapon)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void PoisonDamage()
    {
        GetComponent<EffectDamage>().amount = GetComponent<Stacking>().stacks;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
