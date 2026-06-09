using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBreath : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == "Disposable head"; };
    }


    public void DealDamage(Weapon w)
    {
        GetComponent<EffectDamage>().DealDamage(w);
    }

    public void ApplyByff()
    {
        GetComponent<BuffController>().Equip();
    }
}
