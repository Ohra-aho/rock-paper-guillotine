using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEffects : MonoBehaviour
{
    GameObject buff;
    public void InisiateScissors()
    {
        if(!GetComponent<EffectDamage>()) gameObject.AddComponent<EffectDamage>();
        GetComponent<Weapon>().draw.AddListener(ActivateScissors);
    }

    public void InisiateRock()
    {
        if (!GetComponent<Healing>()) gameObject.AddComponent<Healing>();
        GetComponent<Weapon>().draw.AddListener(ActivateRock);
    }

    public void InisiatePaper()
    {
        buff = Resources.Load<GameObject>("buff/buff");
        GetComponent<Weapon>().draw.AddListener(ActivatePaper);
    }

    public void ActivateScissors()
    {
        int bonus = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            bonus += transform.GetChild(i).GetComponent<Buff>().effect_damage_buff;
        }
        GetComponent<EffectDamage>().DealSetDamage(1+bonus);
    }

    public void ActivateRock()
    {
        GetComponent<Healing>().HealSetAmount(1);
    }

    public void ActivatePaper()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name + "_base";
            new_buff.armor_buff = 1;
            new_buff.temporary = true;
            new_buff.timer = 2;
            new_buff.AddBuff();
        }
    }
}
