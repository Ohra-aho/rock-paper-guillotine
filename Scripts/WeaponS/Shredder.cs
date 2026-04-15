using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().dealDamage = true;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().special = DealDamage;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void DealDamage(Weapon w)
    {
        GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>().TakeDamage(GetComponent<EffectDamage>().amount);
    }
}
