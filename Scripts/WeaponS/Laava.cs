using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laava : MonoBehaviour
{
    private bool buff_on = false;
    [SerializeField] private GameObject buff;
    GameObject real_inventory;

    private void Awake()
    {
        real_inventory = GameObject.FindGameObjectWithTag("RI");
    }

    public void Equip()
    {
        buff_on = true;
    }

    public void Unequip()
    {
        buff_on = false;
    }

    public void AddBuffs()
    {
        if (buff_on)
        {
            for (int i = 0; i < real_inventory.transform.childCount; i++)
            {
                Transform weapon = real_inventory.transform.GetChild(i);
                AddBuff(weapon);
            }
        }
        else
        {
            RemoveBuffs();
        }
    }

    private void AddBuff(Transform weapon)
    {
        if (!IfOwnBuffExists(weapon))
        {
            GameObject new_buff = Instantiate(buff, weapon);
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
            new_buff.GetComponent<Buff>().damage_buff = weapon.GetComponent<Weapon>().armor;
            new_buff.GetComponent<Buff>().armor_buff = -weapon.GetComponent<Weapon>().armor;
            new_buff.GetComponent<Buff>().AddBuff();
        }
    }

    public void RemoveBuffs()
    {
        if (!buff_on)
        {
            for (int i = 0; i < real_inventory.transform.childCount; i++)
            {
                Transform weapon = real_inventory.transform.GetChild(i);
                GameObject own_buff = FindOwnBuff(weapon);
                Destroy(own_buff);
            }
        }
    }

    private bool IfOwnBuffExists(Transform weapon)
    {
        bool found = false;
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
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
