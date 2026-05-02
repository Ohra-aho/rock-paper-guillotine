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
        GetComponent<Weapon>().equip.AddListener(Equip);
        GetComponent<Weapon>().unEquip.AddListener(Unequip);
    }

    public void Equip()
    {
        buff_on = true;
        AddBuffs();
    }

    public void Unequip()
    {
        buff_on = false;
        AddBuffs();
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
            new_buff.GetComponent<Buff>().damage_buff = weapon.GetComponent<Weapon>().GiveEffectiveArmor();
            new_buff.GetComponent<Buff>().armor_buff = -weapon.GetComponent<Weapon>().GiveEffectiveArmor();
            //new_buff.GetComponent<Buff>().endPhase = true;
            /*new_buff.GetComponent<Buff>().special = (Weapon w) =>
            {
                new_buff.GetComponent<Buff>().RemoveBuff();
                new_buff.GetComponent<Buff>().damage_buff = w.GetComponent<Weapon>().GiveEffectiveArmor();
                new_buff.GetComponent<Buff>().armor_buff = -w.GetComponent<Weapon>().GiveEffectiveArmor();
            };*/
            new_buff.GetComponent<Buff>().AddBuff();
        }
    }

    public void ReapplyBuffs()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject buff = RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
            if(buff != null)
            {
                buff.GetComponent<Buff>().RemoveBuff();
                buff.GetComponent<Buff>().damage_buff = RI.transform.GetChild(i).GetComponent<Weapon>().GiveEffectiveArmor();
                buff.GetComponent<Buff>().armor_buff = -RI.transform.GetChild(i).GetComponent<Weapon>().GiveEffectiveArmor();
            }
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
                if(own_buff != null)
                {
                    own_buff.GetComponent<Buff>().RemoveBuff();
                    Destroy(own_buff);
                }
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
