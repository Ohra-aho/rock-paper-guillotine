using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    int previous_HP_gap = 0;

    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Equip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        previous_HP_gap = HB.HP_gap;
        HB.HP_gap = 1;
        HB.DecreaseHealthBar(0, false);
        //previous_max_hp = HB.GiveMaxHealth();
        //int HPbonus = HB.GiveMaxHealth() - 1;
        //HB.DecreaseHealthBar(HPbonus);

    }

    public void Unequip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        //int HPbonus = previous_max_hp - 1;
        HB.HP_gap = previous_HP_gap;
        HB.IncreaseHealthBar(0, false);
    }
}
