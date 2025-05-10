using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuomio : MonoBehaviour
{
    public void Judgement()
    {
        GetComponent<Weapon>().EffectDamage(3);
    }
}
