using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public void Retaliate()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        GetComponent<EffectDamage>().amount = MC.enemyChoise.damage;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
