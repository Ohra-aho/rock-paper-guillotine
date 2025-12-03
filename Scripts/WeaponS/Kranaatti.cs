using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kranaatti : MonoBehaviour
{
    public void DamageBoth()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<EffectDamage>().amount -= 1;
        GetComponent<EffectDamage>().SelfDamage(null);
        GetComponent<EffectDamage>().amount += 1;
    }
}
