using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int amount;

    public void Heal()
    {
        bool valid_heal = false;
        if(amount > 0)
        {
            if (GetComponent<Weapon>().player)
            {
                HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
                if(!HB.CheckIfDead())
                {
                    valid_heal = HB.GiveCurrentHealth() < HB.GiveMaxHealth();
                    HB.HealDamage(amount);
                    if (valid_heal)
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<RLController>().CheckForUnyielding();
                        GetComponent<Weapon>().heal.Invoke();
                    }
                }
            }
            else
            {
                HealthBar HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
                if (!HB.CheckIfDead())
                {
                    valid_heal = HB.GiveCurrentHealth() < HB.GiveMaxHealth();
                    HB.HealDamage(amount);
                    if (valid_heal) GetComponent<Weapon>().heal.Invoke();
                }
            }
        }
    }
}
