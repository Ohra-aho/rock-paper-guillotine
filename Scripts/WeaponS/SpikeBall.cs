using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public int damage;
    public void Retaliate()
    {
        if(GetComponent<Weapon>().player)
        {
            GetComponent<Weapon>().opponent.TakeDamage(
                    GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB, damage
                );
        } else
        {
            GetComponent<Weapon>().opponent.TakeDamage(
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB, damage
                );
        }
    }
}
