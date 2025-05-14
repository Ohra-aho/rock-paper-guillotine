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
        damage_buff = HB.GiveMaxHealth() / 3;
        GetComponent<Weapon>().damage += damage_buff;

    }
}
