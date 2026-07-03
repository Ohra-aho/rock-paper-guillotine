using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().takeDamage = true;
		GetComponent<BuffController>().special = Cushion;
	}

	public void ApplyBuffs()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			if(!weapons[i].FindCertainBuff(GetComponent<Weapon>().name + "_armor"))
			{
				Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[i].transform).GetComponent<Buff>();
				new_buff.temporary = true;
				new_buff.timer = 4;
				new_buff.armor_buff = 1;
				new_buff.reminder = "+1 armor";
				new_buff.id = GetComponent<Weapon>().name + "_armor";
				new_buff.AddBuff();	
			} else
			{
				weapons[i].GetCertainBuff(GetComponent<Weapon>().name + "_armor").GetComponent<Buff>().timer = 4;
			}
		}
	}

	public void Cushion(Weapon w)
    {
        int current_health = w.player_owner.GetComponent<PlayerContoller>().HB.GiveCurrentHealth();
        if (current_health == 1)
        {
            ApplyBuffs();
        }
    }
}
