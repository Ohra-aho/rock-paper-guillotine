using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kranaatti : MonoBehaviour
{
    public int damage;
    public void DamageBoth()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<EffectDamage>().SelfDamage(null);
    }
}
