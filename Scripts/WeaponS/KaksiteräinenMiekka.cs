using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaksiteräinenMiekka : MonoBehaviour
{
    public int damage;
    public void SelfDamage()
    {
        Debug.Log("Self damage");
        if(GetComponent<Weapon>().player)
        {
            GetComponent<Weapon>().TakeDamage(
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB,
                damage
                );
        } else
        {
            GetComponent<Weapon>().TakeDamage(
                GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB,
                damage
                );
        }
    }
}
