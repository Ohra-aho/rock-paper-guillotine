using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pstone : MonoBehaviour
{
    int previous_HP_gap = 0;

    public void Equip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        previous_HP_gap = HB.HP_gap;
        HB.HP_gap = 3;
        HB.DecreaseHealthBar(0, false);
    }

    public void Unequip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.HP_gap = previous_HP_gap;
        HB.IncreaseHealthBar(0, false);
    }
}
