using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearBomb : MonoBehaviour
{
    public void Explosion()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.TakeDamage(HB.GiveCurrentHealth() - 1);
    }
}
