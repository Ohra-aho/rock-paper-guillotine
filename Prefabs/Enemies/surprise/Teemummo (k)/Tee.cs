using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tee : MonoBehaviour
{
    public void HealBoth()
    {
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();
        TC.player_healing++;
        TC.enemy_healing++;

        GameObject.Find("Table").GetComponent<TableController>().player_healing++;
        HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        if (hb.GiveCurrentHealth() < hb.GiveMaxHealth())
        {
            GetComponent<Weapon>().opponent.heal.Invoke();
        }
    }

    public void BuffPlayerWeapon()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        MC.playerChoise.damage++;
    }
}
