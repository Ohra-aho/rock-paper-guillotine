using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int amount;

    public void Heal()
    {
        if(amount > 0)
        {
            if (GetComponent<Weapon>().player)
            {
                HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
                HB.HealDamage(amount);
                GetComponent<Weapon>().heal.Invoke();
            }
            else
            {
                HealthBar HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
                HB.HealDamage(amount);
                GetComponent<Weapon>().heal.Invoke();
            }
        }
    }
}
