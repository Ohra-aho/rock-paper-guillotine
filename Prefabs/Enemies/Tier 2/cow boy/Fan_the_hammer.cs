using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_the_hammer : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().special = GetComponent<EffectDamage>().DealDamage;
    }
}
