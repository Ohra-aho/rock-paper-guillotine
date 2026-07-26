using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string name;
    public string type;
    public int stacks;
    public BuffData[] buffs;
	public int health_increase;
	public bool copy;

    public WeaponData(Weapon weapon)
    {
        name = weapon.gameObject.name.Replace("(Clone)", "");
		MainController.Choise temp_type = weapon.type;
		if(weapon.type != weapon.og_type) temp_type = weapon.og_type; 
        switch(temp_type)
        {
            case MainController.Choise.kivi: type = "kivi"; break;
            case MainController.Choise.paperi: type = "paperi"; break;
            case MainController.Choise.sakset: type = "sakset"; break;
            case MainController.Choise.useless: type = "useless"; break;
            case MainController.Choise.voittamaton: type = "voittamaton"; break;
        }
        if(weapon.GetComponent<Stacking>()) stacks = weapon.GetComponent<Stacking>().stacks;
		if(weapon.GetComponent<HealthIncrease>()) health_increase = weapon.GetComponent<HealthIncrease>().amount;

        buffs = ExtractBuffInfo(weapon);
		if(weapon.name.Contains("Copy")) copy = true;
    }

    public BuffData[] ExtractBuffInfo(Weapon weapon)
    {
        int buff_amount = weapon.transform.childCount;
        BuffData[] buff_data = new BuffData[buff_amount];

        for (int i = 0; i < buff_amount; i++)
        {
            if(!weapon.transform.GetChild(i).GetComponent<Buff>().temporary)
            {
                Debug.Log("Relevant buff found");
                buff_data[i] = new BuffData(weapon.transform.GetChild(i).GetComponent<Buff>());
            }
        }

        return buff_data;
    }
}
