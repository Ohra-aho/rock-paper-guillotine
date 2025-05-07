using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raivo : MonoBehaviour
{
    public int damage_bonus;
    private bool applied = false;
    private int time;
    private void Awake()
    {
        //GetComponent<BuffController>().special_removal = Remove;
        GetComponent<BuffController>().special = Empower;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Empower(Weapon weapon)
    {
        if(time < 2)
        {
            if(time <= 0)
            {
                GameObject true_weapon_holder = GameObject.FindGameObjectWithTag("RIE");
                for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
                {
                    true_weapon_holder.transform.GetChild(i).GetComponent<Weapon>().damage += damage_bonus;
                }
            }
            time = 2;
        }
    }

    public void PowerDown()
    {
        if(time > 0)
        {
            time--;
            if(time <= 0)
            {
                GameObject true_weapon_holder = GameObject.FindGameObjectWithTag("RIE");
                for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
                {
                    true_weapon_holder.transform.GetChild(i).GetComponent<Weapon>().damage -= damage_bonus;
                }
            }
        }
    }
}
