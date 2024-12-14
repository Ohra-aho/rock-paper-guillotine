using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaksiteräinenMiekka : MonoBehaviour
{
    public int damage;
    public void SelfDamage()
    {
        GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerContoller>().TakeDamage(damage);
    }
}
