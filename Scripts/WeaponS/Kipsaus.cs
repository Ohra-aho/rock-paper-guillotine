using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kipsaus : MonoBehaviour
{
    public int heal;
    public void Heal()
    {
        if (GetComponent<Weapon>().player)
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            HB.HealDamage(heal);
        }
        else
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            HB.HealDamage(heal);
        }
        SelfDestruct();
    }

    public void SelfDestruct()
    {
        GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>().RemoveWeapon(this.gameObject);
    }
}
