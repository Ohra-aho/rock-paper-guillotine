using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruuti : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.gameObject.GetComponent<SelfDestruct>(); };
    }

    public void DealDamage(Weapon weapon)
    {
        Debug.Log(weapon.name);
        GetComponent<EffectDamage>().DealDamage(weapon);
        //weapon.EffectDamage(1);
    }
}
