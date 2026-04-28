using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyhäteksti : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().special = DamageOnHeal;
        GetComponent<BuffController>().heal = true;
    }

    public void DamageOnHeal(Weapon weapon)
    {
        GetComponent<EffectDamage>().DealDamage(weapon);
    }

    public void EnemyEffect()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        bool miracle_found = false;
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Mercy" || RI.transform.GetChild(i).GetComponent<Weapon>().name == "Smite" || RI.transform.GetChild(i).GetComponent<Weapon>().name == "Sanctuary")
            {
                miracle_found = true;
                break;
            }
        }
        if(!miracle_found)
        {
            GetComponent<WeaponSpawner>().SpawnRandomWeapon();
        } else
        {
            GetComponent<Weapon>().owner.HB.InstaKill();
        }
    }
}
