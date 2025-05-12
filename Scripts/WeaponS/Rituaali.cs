using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rituaali : MonoBehaviour
{
    public int damage;
    private void Awake()
    {
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void DealDamage(Weapon weapon)
    {
        weapon.EffectDamage(damage);
    }
}
