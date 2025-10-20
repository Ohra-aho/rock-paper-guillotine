using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muuri : MonoBehaviour
{
    //Might need some alteration. Maybe something that activated when reward is collected

    GameObject ri;
    int HP_bonus = 0;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    public void CalculateHP()
    {
        int temp = 0;
        int amount = 0;
        for (int i = 0; i < ri.transform.childCount; i++)
        {
            if (ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.kivi)
            {
                amount++;
                if(amount == 2)
                {
                    temp++;
                    amount = 0;
                }
            }
        }

        if (temp != HP_bonus)
        {
            HP_bonus = temp;
            if(CheckIfEquipped())
            {
                Unequip();
                GetComponent<HealthIncrease>().amount = HP_bonus;
                Equip();
            }
            GetComponent<HealthIncrease>().amount = HP_bonus;
        }
    }

    public void Equip()
    {
        GetComponent<HealthIncrease>().Increase();
    }

    public void Unequip()
    {
        GetComponent<HealthIncrease>().Decrease();
    }

    public bool CheckIfEquipped()
    {
        GameObject pwh = GameObject.Find("PlayerWheelHolder");
        GameObject wheel = pwh.transform.GetChild(0).gameObject;
        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().name == GetComponent<Weapon>().name)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
