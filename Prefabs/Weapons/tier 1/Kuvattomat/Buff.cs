using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buff : MonoBehaviour
{
    public Weapon weapon;
    public string id;

    public int damage_buff;
    public int armor_buff;
    public bool used = false;

    public BuffController.Special special;
    public BuffController.Special special_removal;

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

    public bool awake;
    public bool onDestruction;


    private void Awake()
    {
        weapon = transform.parent.GetComponent<Weapon>();
        if(awake)
        {
            special(weapon);
        }
    }

    private void OnDestroy()
    {
        RemoveBuff();
    }

    public void AddBuff()
    {
        if (damage_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().damage += damage_buff;
        }

        if (armor_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().armor += armor_buff;
        }

        if(choisePhase)
            transform.parent.GetComponent<Weapon>().choisePhase.AddListener(() => special(weapon));
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.AddListener(() => special(weapon));
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.AddListener(() => special(weapon));
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.AddListener(() => special(weapon));
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.AddListener(() => special(weapon));
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.AddListener(() => special(weapon));
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.AddListener(() => special(weapon));
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.AddListener(() => special(weapon));
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.AddListener(() => special(weapon));
        if (onDestruction)
            transform.parent.GetComponent<Weapon>().onDestruction.AddListener(() => special(weapon));
        if (awake)
            special(weapon);
        
    }

    public void RemoveBuff()
    {
        if (damage_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().damage -= damage_buff;
        }

        if (armor_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().armor -= armor_buff;
        }

        if (choisePhase)
            transform.parent.GetComponent<Weapon>().choisePhase.RemoveListener(() => special(weapon));
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.RemoveListener(() => special(weapon));
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.RemoveListener(() => special(weapon));
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.RemoveListener(() => special(weapon));
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.RemoveListener(() => special(weapon));
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.RemoveListener(() => special(weapon));
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.RemoveListener(() => special(weapon));
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.RemoveListener(() => special(weapon));
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.RemoveListener(() => special(weapon));
        if (onDestruction)
            transform.parent.GetComponent<Weapon>().onDestruction.RemoveListener(() => special(weapon));

        if (special_removal != null) special_removal(weapon);
    }
}
