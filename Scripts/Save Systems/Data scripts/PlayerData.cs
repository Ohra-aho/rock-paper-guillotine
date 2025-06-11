using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int max_health;
    public int current_health;
    public int gear;
    public string[] equippend_weapons; 

    public PlayerData(PlayerContoller player)
    {
        gear = player.unlocked_wheel;
        max_health = player.HB.GiveMaxHealth();
        current_health = player.HB.GiveCurrentHealth();

        GameObject wheel = player.WheelHolder.transform.GetChild(0).gameObject;
        equippend_weapons = new string[wheel.transform.childCount - 1];

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                equippend_weapons[i] = wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().name;
            }
        }
    }
}
