using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laastari : MonoBehaviour
{
    public int heal;
    public void Heal()
    {
        if (GetComponent<Weapon>().player)
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            HB.HealDamage(heal);
            GetComponent<Weapon>().heal.Invoke();
        }
        else
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            HB.HealDamage(heal);
            GetComponent<Weapon>().heal.Invoke();
        }
    }
}
