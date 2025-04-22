using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public int damage;
    public void Retaliate()
    {
        GetComponent<Weapon>().opponent.TakeDamage(damage);
    }
}
