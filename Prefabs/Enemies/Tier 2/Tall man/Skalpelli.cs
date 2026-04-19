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

    public void GiveSerum()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Serum>())
            {
                if(RIE.transform.GetChild(i).GetComponent<Stacking>().stacks > 0)
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(0);
                    break;
                } else
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(1);
                    break;
                }
            }
        }
    }
}
