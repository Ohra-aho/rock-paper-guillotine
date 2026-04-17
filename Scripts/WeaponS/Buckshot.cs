using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<EffectDamage>(); };
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().effect_damage_bonus = 2;
    }


}
