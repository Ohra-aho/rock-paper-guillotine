using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muuri : MonoBehaviour
{
    GameObject ri;
    int HP_bonus = 0;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    public void CalculateHP()
    {
        int amount = 0;
        for (int i = 0; i < ri.transform.childCount; i++)
        {
            if (ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.kivi)
            {
                amount++;
            }
        }
        if(amount >= 3) HP_bonus = amount / 3;
    }

    public void Equip()
    {
        CalculateHP();
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.IncreaseHealthBar(HP_bonus);
    }

    public void Unequip()
    {
        CalculateHP();
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.DecreaseHealthBar(HP_bonus);
    }
}
