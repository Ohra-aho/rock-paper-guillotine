using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public GameObject buff;
    public void DebuffOpposingWeapon()
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
                new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
                new_buff.GetComponent<Buff>().timer = 1;
                new_buff.GetComponent<Buff>().special = Burn;
                new_buff.GetComponent<Buff>().endPhase = true;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }

        Demon d = GameObject.Find("demon(Clone)").GetComponent<Demon>();
        d.flames_active = true;
        d.effected_type = MC.playerChoise.type;
    }

    public void Burn(Weapon weapon)
    {
        weapon.SelfDamage(1);
    }
}
