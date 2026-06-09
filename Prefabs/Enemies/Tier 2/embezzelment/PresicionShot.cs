using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresicionShot : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().special = (Weapon w) => { GetComponent<Stacking>().IncreaseStacks(1); };
    }

    public void DealDamage()
    {
        GetComponent<EffectDamage>().amount = GetComponent<Stacking>().stacks / 2;
        GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        GetComponent<Stacking>().stacks = 0;
    }

    public void OffBalance()
    {
        GetComponent<Weapon>().owner.OffBalance();
    }
}
