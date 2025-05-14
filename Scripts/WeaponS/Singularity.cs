using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singularity : MonoBehaviour
{
    public void SelfDamage()
    {
        GetComponent<Weapon>().opponent = this.GetComponent<Weapon>();
        GetComponent<Weapon>().TakeDamage(1);
    }
}
