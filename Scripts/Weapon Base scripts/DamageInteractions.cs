using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInteractions : MonoBehaviour
{
    int current_health = 0;
    int previous_health = 0;

    int current_enemy_health = 0;
    int previous_enemy_health = 0;

    HealthBar HB;
    HealthBar enemy_HB;

    private void Awake()
    {
        if (GetComponent<Weapon>().player)
        {
            HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            enemy_HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
        }
        else
        {
            HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            enemy_HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        }
        GetComponent<Weapon>().choisePhase.AddListener(SetPreviousHealth);
    }

    public void GetCurrentHealth()
    {
        current_health = HB.GiveCurrentHealth();
        current_enemy_health = enemy_HB.GiveCurrentHealth();
    }

    public void SetPreviousHealth()
    {
        previous_health = HB.GiveCurrentHealth();
        previous_enemy_health = enemy_HB.GiveCurrentHealth();
    }

    public int CalculateTakenDamage()
    {
        GetCurrentHealth();
        int taken_damage = previous_health - current_health;
        return taken_damage;
    }

    public int CalculateDealtDamage()
    {
        GetCurrentHealth();
        int dealt_damage = previous_enemy_health - current_enemy_health;
        return dealt_damage;
    }

}
