using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruuti : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void DealDamage(Weapon weapon)
    {
        weapon.EffectDamage(2);
    }
}
