using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorMark : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().draw = true;
		GetComponent<BuffController>().special = (Weapon w) =>
		{
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
			GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
		};
    }
}
