using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaksiteräinenMiekka : MonoBehaviour
{
    public int damage;
    public void SelfDamage()
    {
        GetComponent<Weapon>().TakeDamage(damage);
    }
}
