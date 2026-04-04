using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepeli : MonoBehaviour
{
    GameObject ri;
    int damage_bonus=0;
    PlayerContoller player;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
    }

    public void CalculateDamage()
    {
        if(damage_bonus > 0) GetComponent<Weapon>().damage -= damage_bonus;
        damage_bonus = 0;
        int amount = 0;
        List<Weapon> weapons = player.GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].type == MainController.Choise.sakset)
            {
                amount++;
            }
        }

        damage_bonus = amount;
        if(damage_bonus > 0) GetComponent<Weapon>().damage += damage_bonus;
    }
}
