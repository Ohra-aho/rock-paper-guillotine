using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    public void IcreaseDamage()
    {
        GameObject wheel = GameObject.Find("PlayerWheelHolder").transform.GetChild(0).gameObject;
        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().damage++;
        }
    }
}
