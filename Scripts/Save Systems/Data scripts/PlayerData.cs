using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int max_health;
    public int current_health;
    public int gear;

    public PlayerData(PlayerContoller player)
    {
        gear = player.unlocked_wheel;
        max_health = player.HB.GiveMaxHealth();
        current_health = player.HB.GiveCurrentHealth();
    }
}
