using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public void Weapons()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        MC.playerChoise.damage++;
        if (Chance()) DestroyPlayerWeapon();
    }

    public void Bandages()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.HealDamage(1);
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        MC.playerChoise.damage--;
        if(MC.playerChoise.damage < 0)
        {
            MC.playerChoise.damage = 0;
        }
        if (Chance()) DestroyPlayerWeapon(); 
    }

    public void Supplies()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.IncreaseHealthBar(1, true);
        DestroyPlayerWeapon();
    }

    private void DestroyPlayerWeapon()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        MC.playerChoise.gameObject.AddComponent(typeof(SelfDestruct));
        MC.playerChoise.GetComponent<SelfDestruct>().Destruct();
    }

    private bool Chance()
    {
        int chance = Random.Range(1, 11);
        return chance == 1;
    }
}
