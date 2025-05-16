using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public void RandomiceDamage()
    {
        int damage = Random.Range(0, 5);
        GetComponent<Weapon>().damage = damage;

    }
}
