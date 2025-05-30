using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWeapons : MonoBehaviour
{
    public void TakeDamage()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").transform.GetChild(0).GetComponent<Zombie>().grab = false;
    }

    public void Grab()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").transform.GetChild(0).GetComponent<Zombie>().grab = true;
    }
}
