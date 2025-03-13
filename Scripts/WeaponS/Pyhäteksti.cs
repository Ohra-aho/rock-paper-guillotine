using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyhäteksti : MonoBehaviour
{
    public int damage;
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().special.AddListener(DamageOnHeal);
        GetComponent<BuffController>().heal = true;
    }

    public void DamageOnHeal()
    {
        if (GetComponent<Weapon>().player)
        {
            GetComponent<Weapon>().TakeDamage(
                 GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB,
                 damage
                 );
        }
        else
        {
            GetComponent<Weapon>().TakeDamage(
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB,
                damage
                );
        }
    }
}
