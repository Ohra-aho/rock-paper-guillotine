using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    public void Retaliate()
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() > 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
