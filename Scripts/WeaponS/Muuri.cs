using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muuri : MonoBehaviour
{
    //Might need some alteration. Maybe something that activated when reward is collected

    int HP_bonus = 0;
    PlayerContoller player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
    }

    public void CalculateHP()
    {
        int temp = 0;
        List<Weapon> weapons = player.GetWeapons();
		
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].GetComponent<Weapon>().og_type == MainController.Choise.kivi)
            {
                temp++;
            }
        }
        if (temp != GetComponent<HealthIncrease>().amount)
        {
            if(CheckIfEquipped())
            {
                Unequip();
                GetComponent<HealthIncrease>().amount = temp;
                Equip();
            }
            GetComponent<HealthIncrease>().amount = temp;
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
