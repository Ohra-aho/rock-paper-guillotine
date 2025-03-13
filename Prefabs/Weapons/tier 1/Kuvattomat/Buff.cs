using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buff : MonoBehaviour
{
    public string id;

    public int damage_buff;
    public int armor_buff;
    public bool used = false;

    public UnityEvent special;

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


    private void Awake()
    {
        if(awake)
        {
            special.Invoke();
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
            transform.parent.GetComponent<Weapon>().choisePhase.AddListener(special.Invoke);
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.AddListener(special.Invoke);
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.AddListener( special.Invoke);
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.AddListener( special.Invoke);
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.AddListener( special.Invoke);
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.AddListener( special.Invoke);
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.AddListener( special.Invoke);
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.AddListener(special.Invoke);
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.AddListener( special.Invoke);
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
            transform.parent.GetComponent<Weapon>().choisePhase.RemoveListener(special.Invoke);
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.RemoveListener( special.Invoke);
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.RemoveListener( special.Invoke);
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.RemoveListener( special.Invoke);
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.RemoveListener( special.Invoke);
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.RemoveListener( special.Invoke);
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.RemoveListener( special.Invoke);
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.RemoveListener( special.Invoke);
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.RemoveListener( special.Invoke);
    }
}
