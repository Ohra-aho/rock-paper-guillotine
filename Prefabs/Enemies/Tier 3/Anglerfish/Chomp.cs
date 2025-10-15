using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomp : MonoBehaviour
{
    int amount = 0;
    public void Buff()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        amount = MC.playerChoise.damage;
        GetComponent<Weapon>().damage += amount;
    }

    public void Debuff()
    {
        GetComponent<Weapon>().damage -= amount;
        amount = 0;
    }
}
