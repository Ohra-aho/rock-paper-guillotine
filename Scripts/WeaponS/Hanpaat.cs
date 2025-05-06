using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanpaat : MonoBehaviour
{
    public int heal = 1;
    public void DrainLife()
    {
        if(GetComponent<Weapon>().player)
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            if(!hb.CheckIfDead())
            {
                hb.HealDamage(heal);
                if (GetComponent<Weapon>().heal != null) GetComponent<Weapon>().heal.Invoke();
            }
        } else
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            if (!hb.CheckIfDead())
            {
                hb.HealDamage(heal);
                if (GetComponent<Weapon>().heal != null) GetComponent<Weapon>().heal.Invoke();
            }
        }
    }
}
