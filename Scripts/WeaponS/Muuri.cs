using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muuri : MonoBehaviour
{
    //Might need some alteration. Maybe something that activated when reward is collected

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
        if(amount >= 2) GetComponent<HealthIncrease>().amount = amount / 2;
    }

    public void Equip()
    {
        CalculateHP();
        GetComponent<HealthIncrease>().Increase();
    }

    public void Unequip()
    {
        CalculateHP();
        GetComponent<HealthIncrease>().Decrease();
    }
}
