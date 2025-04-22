using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liekinheitin : MonoBehaviour
{
    public void DealDamageFromArmor()
    {
        GetComponent<Weapon>().opponent.TakeDamage(GetComponent<Weapon>().opponent.armor*2);
    }
}
