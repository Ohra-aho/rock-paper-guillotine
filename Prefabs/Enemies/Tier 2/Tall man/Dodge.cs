using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuffs()
    {
        GetComponent<BuffController>().Equip();
    }

    public void GiveSerum()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<Serum>())
            {
                if (RIE.transform.GetChild(i).GetComponent<Stacking>().stacks > 0)
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(0);
                    break;
                }
                else
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(1);
                    break;
                }
            }
        }
    }
}
