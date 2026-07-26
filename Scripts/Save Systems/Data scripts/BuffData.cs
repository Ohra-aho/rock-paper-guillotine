using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuffData
{
    public string id;
	public int damage_buff;
	public int armor_buff;
	public int effect_damage_buff;
	public int toughness_buff;
	public bool special;

    public BuffData(Buff buff)
    {
        id = buff.id;
		damage_buff = buff.damage_buff;
		armor_buff = buff.armor_buff;
		effect_damage_buff = buff.effect_damage_buff;
		toughness_buff = buff.toughness_buff;
		if(buff.special != null)
			if(buff.special.GetInvocationList().Length > 0) special = true;
    }
}
