using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teramyrsky : MonoBehaviour
{
    //Put a pin on thsi one


    public int damage_bonus;
    private bool buff_on = false;
    [SerializeField] private GameObject buff;
    GameObject real_inventory;
    public delegate bool Requirement(Weapon weapon);
    public Requirement buff_requirement;

    //To where put special
    public bool choisePhase;
    public bool resultPhase;
    public bool endPhase;
    public bool victory;

    public bool takeDamage;
    public bool dealDamage;
    public bool draw;
    public bool heal;

    public bool equip;
    public bool unEquip;

    public bool constant;

    private void Awake()
    {
        real_inventory = GameObject.FindGameObjectWithTag("RI");
        GetComponent<Weapon>().equip.AddListener(Equip);
        GetComponent<Weapon>().unEquip.AddListener(Unequip);
        GetComponent<Weapon>().constant.AddListener(AddBuffs);
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
                if (weapon.name != GetComponent<Weapon>().name)
                {
                    AddBuff(weapon);
                }
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
            Buff new_buff = Instantiate(buff, weapon).GetComponent<Buff>();
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
            new_buff.GetComponent<Buff>().damage_buff = damage_bonus;
            new_buff.choisePhase = choisePhase;
            new_buff.resultPhase = resultPhase;
            new_buff.endPhase = endPhase;
            new_buff.victory = victory;
            new_buff.takeDamage = takeDamage;
            new_buff.dealDamage = dealDamage;
            new_buff.draw = draw;
            new_buff.heal = heal;
            new_buff.constant = constant;
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
