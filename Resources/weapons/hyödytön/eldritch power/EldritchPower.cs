using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchPower : MonoBehaviour
{
    public GameObject buff;
    bool health_increased = false;

    public void IncreaseHealth()
    {
        if(!health_increased)
        {
            GetComponent<HealthIncrease>().Increase();
            health_increased = true;
        }
    }

    public void BuffDamage()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        Weapon weakest = null;
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weakest == null)
            {
                weakest = weapons[i];
            } else
            {
                if(weapons[i].GiveEffectiveDamage() < weakest.GiveEffectiveDamage())
                {
                    weakest = weapons[i];
                }
            }
        }

        Buff newBuff = Instantiate(buff, weakest.gameObject.transform).GetComponent<Buff>();
        newBuff.damage_buff = 1;
        newBuff.temporary = true;
        newBuff.timer = 1000;
        newBuff.id = this.GetComponent<Weapon>().name;
        newBuff.AddBuff();
    }

    public void GiveAuthority()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        List<Weapon> buffable_weapons = new List<Weapon>();

        for (int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].type != MainController.Choise.voittamaton)
            {
                buffable_weapons.Add(weapons[i]);
            }
        }

        if(buffable_weapons.Count > 0)
        {
            Weapon to_buff = buffable_weapons[Random.Range(0, buffable_weapons.Count)];

            Buff newBuff = Instantiate(buff, to_buff.gameObject.transform).GetComponent<Buff>();
            newBuff.type_change = MainController.Choise.voittamaton;
            newBuff.temporary = true;
            newBuff.timer = 1;
            newBuff.id = this.GetComponent<Weapon>().name;
            newBuff.AddBuff();
        }

    }
}
