using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laava : MonoBehaviour
{
    [SerializeField] private GameObject buff;
    GameObject real_inventory;

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().heal = true;
		GetComponent<BuffController>().special = AddBuffs;
    }

    public void AddBuffs(Weapon w)
    {
		real_inventory = GameObject.FindGameObjectWithTag("RI");
		for (int i = 0; i < real_inventory.transform.childCount; i++)
		{
			Transform weapon = real_inventory.transform.GetChild(i);
			AddBuff(weapon);
		} 
    }

    private void AddBuff(Transform weapon)
    {
        if (!IfOwnBuffExists(weapon))
        {
            GameObject new_buff = Instantiate(GetComponent<BuffController>().buff, weapon);
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name+"_2";
            new_buff.GetComponent<Buff>().damage_buff = 1;
			new_buff.GetComponent<Buff>().temporary = true;
			new_buff.GetComponent<Buff>().timer = 2;
        }
    }

    private bool IfOwnBuffExists(Transform weapon)
    {
        bool found = false;
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name+"_2")
            {
                found = true;
            }
        }
        return found;
    }

    private GameObject FindOwnBuff(Transform weapon)
    {
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
            {
                return weapon.GetChild(i).gameObject;
            }
        }
        return null;
    }
}
