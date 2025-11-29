using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardboard : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special_apply = true;
    }

    public void AppluBuffs()
    {
        if (CheckIfLavaEquipped()) GetComponent<BuffController>().damage_bonus = 1;
        else GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().Equip();
    }

    private bool CheckIfLavaEquipped()
    {
        bool yes = false;
        List<Weapon> temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < temp.Count; i++)
        {
            if(temp[i].name == "Lava")
            {
                yes = true;
                break;
            }
        }
        return yes;
    }
}
