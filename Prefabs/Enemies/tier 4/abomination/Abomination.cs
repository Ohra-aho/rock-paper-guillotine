using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abomination : MonoBehaviour
{
    public GameObject buff;
    public void UseAdapt()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        int useless_count = 0;
        // change 2 to useless
        bool buff_active = RIE.transform.GetChild(1).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name);
        if(!buff_active)
        {
            while (useless_count < 2)
            {
                for (int i = Random.Range(0, RIE.transform.childCount); i < RIE.transform.childCount; i++)
                {
                    if (RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name && !RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
                    {
                        Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                        new_buff.type_change = MainController.Choise.useless;
                        new_buff.id = GetComponent<Weapon>().name;
                        new_buff.temporary = true;
                        new_buff.timer = 3;
                        new_buff.AddBuff();
                        useless_count++;
                    }
                }
            }
        }
        // Change 1 to unbeatable
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name && !RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
            {
                Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.type_change = MainController.Choise.voittamaton;
                new_buff.id = GetComponent<Weapon>().name;
                new_buff.temporary = true;
                new_buff.timer = 3;
                new_buff.AddBuff();
            }
        }
    }

    public void Unstoppable()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if(!RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
            {
                Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.id = GetComponent<Weapon>().name;
                new_buff.draw_winner = true;
                new_buff.AddBuff();
            }
        }
    }

    public void Unbeateble()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (!RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
            {
                Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.id = GetComponent<Weapon>().name;
                new_buff.draw = true;
                new_buff.special = (Weapon w) => { GetComponent<EffectDamage>().DealDamage(w); };
                new_buff.AddBuff();
            }
        }
    }

    public void Unkillable()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (!RIE.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
            {
                Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.id = GetComponent<Weapon>().name;
                new_buff.draw = true;
                new_buff.special = (Weapon w) => { GetComponent<Healing>().Heal(); };
                new_buff.AddBuff();
            }
        }
    }
}
