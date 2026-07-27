using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int max_health;
    public int current_health;
	public int removed_damage;
    public int gear;

    public PlayerData(PlayerContoller player)
    {
        gear = player.unlocked_wheel;
        max_health = player.HB.GiveTrueMaxHealth();
        current_health = player.HB.GiveCurrentHealth();
		removed_damage = player.HB.removed_damage;
    }
}
