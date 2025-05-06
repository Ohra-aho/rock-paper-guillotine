using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuffController : MonoBehaviour
{
    private bool buff_on = false;
    [SerializeField] private GameObject buff;
    GameObject real_inventory;
    [HideInInspector] public int damage_bonus = 0;
    [HideInInspector] public int armor_bonus = 0;
    //[HideInInspector] public UnityEvent special;
    public delegate void Special(Weapon weapon);
    public Special special;
    public Special special_removal;
    public delegate bool Requirement(Weapon weapon);
    public Requirement buff_requirement;

    //To where put special
    [HideInInspector] public bool choisePhase;
    [HideInInspector] public bool resultPhase;
    [HideInInspector] public bool endPhase;
    [HideInInspector] public bool victory;
    [HideInInspector] public bool special_apply;

    [HideInInspector] public bool takeDamage;
    [HideInInspector] public bool dealDamage;
    [HideInInspector] public bool draw;
    [HideInInspector] public bool win;
    [HideInInspector] public bool lose;
    [HideInInspector] public bool heal;

    [HideInInspector] public bool equip;
    [HideInInspector] public bool unEquip;

    [HideInInspector] public bool constant;
    [HideInInspector] public bool onDestruction;
    [HideInInspector] public bool awake;
    [HideInInspector] public bool temporary;
    [HideInInspector] public int timer; //used for temporary buffs

    private void Awake()
    {
        Inisiate();
    }

    public void Inisiate() 
    {
        if (GetComponent<Weapon>().player)
        {
            real_inventory = GameObject.FindGameObjectWithTag("RI");
            GetComponent<Weapon>().equip.AddListener(Equip);
            GetComponent<Weapon>().unEquip.AddListener(Unequip);
        }
        else
        {
            Debug.Log("WTF");
            real_inventory = GameObject.FindGameObjectWithTag("RIE");
        }
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
                if (buff_requirement(weapon.GetComponent<Weapon>()))
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
            new_buff.GetComponent<Buff>().armor_buff = armor_bonus;
            new_buff.choisePhase = choisePhase;
            new_buff.resultPhase = resultPhase;
            new_buff.endPhase = endPhase;
            new_buff.victory = victory;
            new_buff.takeDamage = takeDamage;
            new_buff.dealDamage = dealDamage;
            new_buff.draw = draw;
            new_buff.heal = heal;
            new_buff.constant = constant;
            new_buff.onDestruction = onDestruction;
            new_buff.awake = awake;
            new_buff.win = win;
            new_buff.lose = lose;
            new_buff.temporary = temporary;
            new_buff.timer = timer;
            if(special != null) new_buff.GetComponent<Buff>().special = special;
            if (special_removal != null) new_buff.GetComponent<Buff>().special_removal = special_removal;
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
