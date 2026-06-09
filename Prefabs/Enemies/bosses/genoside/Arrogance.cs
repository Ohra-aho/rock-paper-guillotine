using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrogance : MonoBehaviour
{
    bool choise_phase = true;
    int current_HP;
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void DealDamage(Weapon weapon)
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() <= 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        } else
        {
            GetComponent<EffectDamage>().SelfDamage(null);
        }
    }
}
