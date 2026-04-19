using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackpot : MonoBehaviour
{
    public void DeathTrigger()
    {
        if(GetComponent<Weapon>().owner.GetComponent<BasicEnemy>().HB.dead)
        {
            GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
            GameObject RI = GameObject.FindGameObjectWithTag("RI");
            for(int i = 0; i < RI.transform.childCount; i++)
            {
                if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Price")
                {
                    RI.transform.GetChild(i).GetComponent<Stacking>().stacks = GetComponent<Stacking>().stacks;
                    break;
                }
            }
        }
    }
}
