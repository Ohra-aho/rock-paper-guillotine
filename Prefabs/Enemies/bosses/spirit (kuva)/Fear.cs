using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().special = Debuff;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Debuff(Weapon w)
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        string weapon_name = MC.playerChoise.name;
        GameObject.Find("Spirit(Clone)").GetComponent<Spirit>().debuff_active = true;
        GameObject.Find("Spirit(Clone)").GetComponent<Spirit>().debuffed_type = MC.playerChoise.type;

        for (int i = 0; i < RI.transform.childCount; i++)
        {
            if (RI.transform.GetChild(i).GetComponent<Weapon>().name == weapon_name)
            {
                GameObject weapon = RI.transform.GetChild(i).gameObject;
                GameObject new_buff = Instantiate(GetComponent<BuffController>().buff, weapon.transform);
                new_buff.GetComponent<Buff>().timer = 1;
                new_buff.GetComponent<Buff>().type_change = MainController.Choise.hyödytön;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }
    }
}
