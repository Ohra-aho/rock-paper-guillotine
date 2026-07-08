using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teramyrsky : MonoBehaviour
{
    public int damage_bonus;
    private void Awake()
    {
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().destructive = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => {
            if (!weapon.gameObject.GetComponent<SelfDestruct>() && weapon.name != this.GetComponent<Weapon>().name) return true;
            else return false;
        };
		GetComponent<BuffController>().special = (Weapon w) => { GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>()); };
		GetComponent<BuffController>().reminder = "After use, deals 2 damage and destroys itself.";
    }
}
