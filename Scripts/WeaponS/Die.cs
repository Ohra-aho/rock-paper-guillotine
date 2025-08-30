using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int max = 4;
    int previous_damage = 0;
    public void RandomiceDamage()
    {
        int damage = Random.Range(0, max);
        GetComponent<Weapon>().damage -= previous_damage;
        GetComponent<Weapon>().damage += damage;
        previous_damage = damage;
    }
}
