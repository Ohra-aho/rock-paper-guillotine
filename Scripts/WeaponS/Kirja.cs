using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kirja : MonoBehaviour
{

    GameObject ri;
    int armor_bonus = 0;
    PlayerContoller player;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
    }

    public void CalculateHP()
    {
        int amount = 0;
        GetComponent<Weapon>().armor -= armor_bonus;
        List<Weapon> weapons = player.GetWeapons();
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].type == MainController.Choise.paperi && weapons[i].name != GetComponent<Weapon>().name)
            {
                amount++;
            }
        }
        armor_bonus = amount;
        GetComponent<Weapon>().armor += armor_bonus;
    }
}
