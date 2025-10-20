using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{

    GameObject ri;
    int armor_bonus = 0;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    public void CalculateHP()
    {
        int amount = 0;
        GetComponent<Weapon>().armor -= armor_bonus;
        for (int i = 0; i < ri.transform.childCount; i++)
        {
            if (ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.paperi)
            {
                amount++;
            }
        }
        armor_bonus = amount / 3;
        GetComponent<Weapon>().armor += armor_bonus;
    }
}
