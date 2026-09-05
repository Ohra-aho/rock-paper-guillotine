using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teramyrsky : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().draw = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => {return true;};
		GetComponent<BuffController>().special = (Weapon w) => { GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>()); };
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().reminder = "If draws, deals 1 damage.";
    }
}
