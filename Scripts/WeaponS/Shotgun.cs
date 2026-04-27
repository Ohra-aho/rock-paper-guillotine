using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public void Activate()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder");

        enemy.GetComponent<EnemyController>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        enemy.GetComponent<EnemyController>().dead = enemy.GetComponent<EnemyController>().HB.CheckIfDead();
        GetComponent<Weapon>().deal_effect_damage.Invoke();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        GetComponent<Weapon>().takeDamage.Invoke();
    }
}
