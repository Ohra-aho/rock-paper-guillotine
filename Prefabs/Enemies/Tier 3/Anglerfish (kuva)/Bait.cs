using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public GameObject buff;
    public void BuffOpposingWeapon()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        string weapon_name = MC.playerChoise.name;

        for (int i = 0; i < RI.transform.childCount; i++)
        {
            if (RI.transform.GetChild(i).GetComponent<Weapon>().name == weapon_name)
            {
                GameObject weapon = RI.transform.GetChild(i).gameObject;
                GameObject new_buff = Instantiate(buff, weapon.transform);
                new_buff.GetComponent<Buff>().timer = 1;
                new_buff.GetComponent<Buff>().damage_buff = 2;
                new_buff.GetComponent<Buff>().AddBuff();
                GameObject.Find("Anglerfish(Clone)").GetComponent<Anglerfish>().bait = true;
                GameObject.Find("Anglerfish(Clone)").GetComponent<Anglerfish>().baited_type = weapon.GetComponent<Weapon>().type;
            }
        }

    }
}
