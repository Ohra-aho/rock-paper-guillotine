using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : MonoBehaviour
{
    public void Cushion()
    {
        int current_health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth();
        int damage = GameObject.Find("Table").GetComponent<TableController>().player_damage;
        if (current_health - damage == 1 && GameObject.Find("Table").GetComponent<TableController>().player_healing == 0)
        {
            GetComponent<Healing>().Heal();
        }
    }
}
