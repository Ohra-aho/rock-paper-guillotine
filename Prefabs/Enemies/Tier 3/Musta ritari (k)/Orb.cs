using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public void HealOpponent()
    {
        int damage = GetComponent<DamageInteractions>().CalculateTakenDamage();
        if(damage <= 0)
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            HB.HealDamage(1);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>().playerChoise.heal.Invoke();
        }
    }
}
