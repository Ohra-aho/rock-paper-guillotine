using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halberg : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<EffectDamage>().amount = 1;
    }

    public void DamageOnDraw()
    {
        GetComponent<EffectDamage>().DealDamage();
    }
}
