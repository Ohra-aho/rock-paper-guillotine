using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrigadi : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<BuffController>().damage_bonus = -1;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = GetComponent<EffectDamage>().DealDamage;
    }


}
