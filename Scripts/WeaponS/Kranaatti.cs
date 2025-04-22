using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kranaatti : MonoBehaviour
{
    public int damage;
    public void DamageBoth()
    {
        GetComponent<Weapon>().opponent.TakeDamage(
                damage
            );
        GetComponent<Weapon>().TakeDamage(
                damage
            );
    }
}
