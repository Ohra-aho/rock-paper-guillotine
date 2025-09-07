using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<EffectDamage>(); };
        GetComponent<BuffController>().effect_damage_bonus = 1;
    }
}
