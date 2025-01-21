using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Järkäle : MonoBehaviour
{
    public int HPbonus;

    public void Equip()
    {
        Debug.Log("Equip");
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().maxHealth += HPbonus;
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.IncreaseHealthBar(HPbonus);
    }

    public void Unequip()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().maxHealth -= HPbonus;
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.DecreaseHealthBar(HPbonus);
    }
}
