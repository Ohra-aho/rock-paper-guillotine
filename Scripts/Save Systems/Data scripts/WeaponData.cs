using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string name;
    public string type;
    public int stacks;
    public BuffData[] buffs;
    public bool self_destruct_used;

    public WeaponData(Weapon weapon)
    {
        name = weapon.name;
        switch(weapon.type)
        {
            case MainController.Choise.kivi: type = "kivi"; break;
            case MainController.Choise.paperi: type = "paperi"; break;
            case MainController.Choise.sakset: type = "sakset"; break;
            case MainController.Choise.hyödytön: type = "hyödytön"; break;
            case MainController.Choise.voittamaton: type = "voittamaton"; break;
        }
        if(weapon.GetComponent<Stacking>()) stacks = weapon.GetComponent<Stacking>().stacks;

        buffs = ExtractBuffInfo(weapon);

        if(weapon.gameObject.GetComponent<SelfDestruct>())
        {
            self_destruct_used = weapon.gameObject.GetComponent<SelfDestruct>().used_ones;
        }

    }

    public BuffData[] ExtractBuffInfo(Weapon weapon)
    {
        int buff_amount = weapon.transform.childCount;
        BuffData[] buff_data = new BuffData[buff_amount];

        for (int i = 0; i < buff_amount; i++)
        {
            if(weapon.transform.GetChild(i).GetComponent<Buff>().used)
            {
                Debug.Log("Relevant buff found");
                buff_data[i] = new BuffData(weapon.transform.GetChild(i).GetComponent<Buff>());
            } else if(weapon.transform.GetChild(i).GetComponent<Buff>().timer > 0)
            {
                Debug.Log("Relevant buff found");
                buff_data[i] = new BuffData(weapon.transform.GetChild(i).GetComponent<Buff>());
            }
        }

        return buff_data;
    }
}
