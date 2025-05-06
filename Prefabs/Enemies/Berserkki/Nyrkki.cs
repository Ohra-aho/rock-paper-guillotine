using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyrkki : MonoBehaviour
{
    public void SelfDamage()
    {
        GetComponent<Weapon>().TakeDamage(1);
    }
}
