using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kilpimuuri : MonoBehaviour
{
    public void DecreaseDamage()
    {
        Transform RIE = GameObject.FindGameObjectWithTag("RIE").transform;
        int amount = RIE.childCount;
        for(int i = 0; i < amount; i++)
        {
            if(RIE.GetChild(i).GetComponent<Weapon>().damage > 1)
            {
                RIE.GetChild(i).GetComponent<Weapon>().damage--;
                if (RIE.GetChild(i).GetComponent<Weapon>().damage < 1)
                {
                    RIE.GetChild(i).GetComponent<Weapon>().damage = 1;
                }
            }
        }
    }

    public void Lose()
    {
        GetComponent<Weapon>().owner.OffBalance();
    }

    public void SetPreviousWeapon()
    {
        GameObject enemy = GameObject.Find("EnemyHolder").transform.GetChild(0).gameObject;
        enemy.GetComponent<Army>().previous_weapon = this.GetComponent<Weapon>();
        enemy.GetComponent<BasicEnemy>().Balance();
    }
}
