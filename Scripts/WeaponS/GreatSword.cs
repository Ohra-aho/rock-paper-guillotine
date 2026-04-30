using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSword : MonoBehaviour
{
    int damage_buff = 0;
    public void CheckMaxHealth()
    {
        GetComponent<Weapon>().damage -= damage_buff;
        damage_buff = 0;
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        damage_buff = HB.GiveCurrentHealth() / 2;
        GetComponent<Weapon>().damage += damage_buff;

    }

    public void EnemyEffect()
    {
        GetComponent<Weapon>().damage -= damage_buff;
        damage_buff = 0;
        HealthBar HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
        damage_buff = HB.GiveCurrentHealth() / 3;
        GetComponent<Weapon>().damage += damage_buff;
    }
}
