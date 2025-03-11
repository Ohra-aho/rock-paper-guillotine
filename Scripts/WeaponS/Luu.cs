using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luu : MonoBehaviour
{
    public int HPbonus;

    public void Equip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.DecreaseHealthBar(HPbonus);
    }

    public void Unequip()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.IncreaseHealthBar(HPbonus);
    }
}
