using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().special = GetComponent<EffectDamage>().DealDamage;
    }
}
