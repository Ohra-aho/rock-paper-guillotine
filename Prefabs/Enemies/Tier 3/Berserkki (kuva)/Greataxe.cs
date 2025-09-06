using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greataxe : MonoBehaviour
{
    public void Tenacity()
    {
        int damage = GetComponent<DamageInteractions>().CalculateTakenDamage();
        if(damage <= 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
