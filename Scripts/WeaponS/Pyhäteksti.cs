using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyhäteksti : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().special = DamageOnHeal;
        GetComponent<BuffController>().heal = true;
    }

    public void DamageOnHeal(Weapon weapon)
    {
        GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
    }
}
