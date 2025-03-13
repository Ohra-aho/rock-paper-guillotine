using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuolonSopimus : MonoBehaviour
{
    public int damage;
    public void SelfDamage()
    {
        GetComponent<Weapon>().TakeDamage(null, damage);
    }
}
