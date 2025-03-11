using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kranaatti : MonoBehaviour
{
    public int damage;
    public void DamageBoth()
    {
        GetComponent<Weapon>().opponent.TakeDamage(
                GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB, damage
            );
        GetComponent<Weapon>().opponent.TakeDamage(
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB, damage
            );
        SelfDestruct();
    }

    public void SelfDestruct()
    {
        GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>().RemoveWeapon(this.gameObject);
    }
}
