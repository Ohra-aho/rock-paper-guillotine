using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sirpaleet : MonoBehaviour
{
    public int damage;
    public void OnDeath()
    {
        if(GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>().CheckIfDead())
        {
            GetComponent<Weapon>().EffectDamage(damage);
        }
    }
}
