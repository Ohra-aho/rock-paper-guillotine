using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turmio : MonoBehaviour
{
    public int damage;
    public void DealDamageToBoth()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<EffectDamage>().SelfDamage(null);
    }
}
