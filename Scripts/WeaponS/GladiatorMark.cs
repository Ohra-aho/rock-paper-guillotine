using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorMark : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().special = DealDamage;
    }

    public void DealDamage(Weapon w)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.Find("EnemyHolder");
        if (player.GetComponent<PlayerContoller>().damage_taken)
        {
            GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
        }
        if(enemy.GetComponent<EnemyController>().damage_taken)
        {
            GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        }
    }
}
