using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInteractions : MonoBehaviour
{
    int current_health = 0;
    int previous_health = 0;

    HealthBar HB;

    private void Awake()
    {
        if (GetComponent<Weapon>().player) HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        else HB = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;

        GetComponent<Weapon>().choisePhase.AddListener(SetPreviousHealth);
        //GetComponent<Weapon>().endPhase.AddListener(GetCurrentHealth);
    }

    public void GetCurrentHealth()
    {
        current_health = HB.GiveCurrentHealth();
    }

    public void SetPreviousHealth()
    {
        previous_health = HB.GiveCurrentHealth();
    }

    public int CalculateTakenDamage()
    {
        GetCurrentHealth();
        Debug.Log("previous health: "+previous_health);
        Debug.Log("current health: "+current_health);
        int taken_damage = previous_health - current_health;
        return taken_damage;
    }

}
