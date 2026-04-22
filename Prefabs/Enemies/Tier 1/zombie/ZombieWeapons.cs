using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWeapons : MonoBehaviour
{
    private void Awake()
    {
        if(GetComponent<BuffController>())
        {
            GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
            GetComponent<BuffController>().win = true;
            GetComponent<BuffController>().draw = true;
            GetComponent<BuffController>().temporary = true;
            GetComponent<BuffController>().timer = 2;
            GetComponent<BuffController>().special = GiveDebuff;
            GetComponent<BuffController>().special_apply = true;
        }
    }

    public void GiveDebuff(Weapon w)
    {
        GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
    }

    public void BodyLoss() 
    {
        GetComponent<Weapon>().owner.HB.InstaKill();
    }
}
