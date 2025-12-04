using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public void Activate()
    {
        HealthBar player_HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HealthBar enemy_HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();

        enemy_HB.TakeDamage(GetComponent<EffectDamage>().amount);
        GetComponent<Weapon>().deal_effect_damage.Invoke();
        GetComponent<EffectDamage>().SelfDamage(null);
    }
}
