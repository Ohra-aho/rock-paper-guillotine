using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().special = (Weapon w) => { GetComponent<EffectDamage>().SelfDamage(w); };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void ApplyBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
