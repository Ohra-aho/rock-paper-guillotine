using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    public int amount;
    public void DealDamage()
    {
        GetComponent<Weapon>().EffectDamage(amount);
    }
}
