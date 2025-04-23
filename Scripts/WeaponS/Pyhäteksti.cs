using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyhäteksti : MonoBehaviour
{
    public int damage;
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().special = DamageOnHeal;
        GetComponent<BuffController>().heal = true;
        if (!GetComponent<Weapon>().player) GetComponent<BuffController>().Equip();
    }

    public void DamageOnHeal(Weapon weapon)
    {
        weapon.EffectDamage(damage);   
    }
}
