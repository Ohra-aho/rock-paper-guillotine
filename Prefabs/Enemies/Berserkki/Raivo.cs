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
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        //GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Empower(Weapon weapon)
    {
        Debug.Log("Empower");
        //GetComponent<BuffController>().Equip();
    }

    public void Remove()
    {
        Debug.Log("Jotai j‰nn‰‰");
        if(applied)
        {
            GameObject true_weapon_holder = GameObject.FindGameObjectWithTag("RIE");
            for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
            {
                true_weapon_holder.transform.GetChild(i).GetComponent<Weapon>().damage -= damage_bonus;
            }
            applied = false;
        }
    }
}
