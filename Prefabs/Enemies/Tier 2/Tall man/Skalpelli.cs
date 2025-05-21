using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skalpelli : MonoBehaviour
{
    private void Awake()
    {
        CheckForBuff();
        GetComponent<Weapon>().endPhase.AddListener(CheckForBuff);
    }

    public void CheckForBuff()
    {
        EnemyController ec = GameObject.Find("EnemyHolder").GetComponent<EnemyController>();
        int ch = ec.GiveCurrentHealth();
        if(ch < ec.currentEnemy.GetComponent<BasicEnemy>().maxHealth)
        {
            GetComponent<Weapon>().damage = 2;
        } else
        {
            GetComponent<Weapon>().damage = 4;
        }
    }
}
