using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public GameObject buff;
    public void TakeDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(1);
    }

    public void DealPoisonDamage()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        int poisons = -1;
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
            {
                poisons++;
            }
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(poisons);
    }

    public void DebuffDamage(int amount)
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        Weapon strongest = RI.transform.GetChild(0).GetComponent<Weapon>();
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            Buff buff_already = CheckIfDebuffExists(RI.transform.GetChild(i));

            int damage = RI.transform.GetChild(i).GetComponent<Weapon>().damage;
            if(buff_already != null)
            {
                damage += buff_already.damage_buff;
            }

            if (damage > strongest.damage)
            {
                strongest = RI.transform.GetChild(i).GetComponent<Weapon>();
            } else if(damage == strongest.damage)
            {
                int chance = Random.Range(0, 2);
                if(chance == 1)
                {
                    strongest = RI.transform.GetChild(i).GetComponent<Weapon>();
                }
            }
        }

        Buff old_buff = CheckIfDebuffExists(strongest.transform);
        if(old_buff != null)
        {
            old_buff.damage_buff -= amount;
        } else
        {
            Buff new_buff = Instantiate(buff, strongest.transform).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name;
            new_buff.damage_buff = -amount;
            new_buff.temporary = true;
            new_buff.timer = 1000;
            new_buff.AddBuff();
        }
    }

    public Buff CheckIfDebuffExists(Transform weapon)
    {
        for(int i = 0; i < weapon.childCount; i++)
        {
            if(weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
            {
                return weapon.GetChild(i).GetComponent<Buff>();
            }
        }
        return null;
    }
}
