using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().destructive = true;
    }

    public void AppluBuffs()
    {
        GetComponent<BuffController>().Equip();
    }

    public void DealDamage(Weapon w)
    {
        GetComponent<EffectDamage>().DealDamage(w);
    }
}
