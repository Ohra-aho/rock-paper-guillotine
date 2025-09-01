using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCold : MonoBehaviour
{
    public void Retaliate()
    {
        int taken_damage = GetComponent<DamageInteractions>().CalculateTakenDamage();
        GetComponent<EffectDamage>().amount = taken_damage;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
