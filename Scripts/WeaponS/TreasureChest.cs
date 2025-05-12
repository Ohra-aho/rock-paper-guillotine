using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public void IncreaseAllPoints()
    {
        //Will need universal point system!!!!!
        GameObject wheel = GameObject.Find("PlayerWheelHolder").transform.GetChild(0).gameObject;

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            GameObject weapon = wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon;
            if (weapon.GetComponent<Weapon>().points)
            {
                weapon.GetComponent<Weapon>().stacks++;
            }
        }
    }
}
