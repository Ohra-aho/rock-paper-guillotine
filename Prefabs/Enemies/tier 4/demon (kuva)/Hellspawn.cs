using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellspawn : MonoBehaviour
{
    int previous_health = 8;

    HealthBar HB;
    private void Awake()
    {
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = Retaliate;

        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();
    }

    public void Retaliate(Weapon weapon)
    {
        if(previous_health > HB.GiveCurrentHealth())
        {
            int difference = previous_health - HB.GiveCurrentHealth();
            GetComponent<EffectDamage>().amount = difference;
            GetComponent<EffectDamage>().DealDamage(weapon);
        }
        GetComponent<EffectDamage>().amount = 1;
        if(weapon.name != this.GetComponent<Weapon>().name) GetComponent<EffectDamage>().SelfDamage(weapon);
        previous_health = HB.GiveCurrentHealth();
        GetComponent<EffectDamage>().amount = 0;
    }
}
