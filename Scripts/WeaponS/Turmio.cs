using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turmio : MonoBehaviour
{
    public int damage;
    public void DealDamageToBoth()
    {
        GetComponent<Weapon>().opponent.TakeDamage(damage);
        GetComponent<Weapon>().TakeDamage(damage);
    }
}
