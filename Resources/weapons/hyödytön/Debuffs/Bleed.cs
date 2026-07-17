using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public GameObject buff;

	void OnDestroy()
	{
		if(GetComponent<Weapon>().name == "Weakness") RemoveBuffs();
	}

	public void TakeDamage()
    {
		HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        HB.TakeDamage(1);
		if(!HB.CheckIfDead())
		{
			List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetComponent<PlayerContoller>().GetWeapons();
			if(weapons.Count > 0)
			{
				if(weapons[0].transform.childCount > 0)
				{
					for(int i = 0; i < weapons[0].transform.childCount; i++)
					{
						if(weapons[0].transform.GetChild(i).GetComponent<Buff>().takeDamage)
						{
							weapons[0].transform.GetChild(i).GetComponent<Buff>().special.Invoke(weapons[0]);
						}
					}
				}
			}	
		}
    }

    public void DealPoisonDamage()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        int poisons = -1;
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
            {
				if(!weapons.Contains(RI.transform.GetChild(i).GetComponent<Weapon>()))
				{
                	poisons++;
				}
            }
        }
        GameObject.Find("Table").GetComponent<TableController>().player_direct_damage += poisons;
    }

    public void DebuffDamage(int amount)
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		List<Weapon> possible_weapons = new List<Weapon>();

		for(int i = 0; i < weapons.Count; i++)
		{
			if(!weapons[i].FindCertainBuff(GetComponent<Weapon>().name))
			{
				possible_weapons.Add(weapons[i]);
			}
		}

		if(possible_weapons.Count > 0)
		{
			Weapon strongest = possible_weapons[0];
			for(int i = 0; i < possible_weapons.Count; i++)
			{
				int damage = possible_weapons[i].GetComponent<Weapon>().GiveEffectiveDamage();
				if (damage > strongest.GiveEffectiveDamage())
				{
					strongest = possible_weapons[i];
				} else if(damage == strongest.GiveEffectiveDamage())
				{
					int chance = Random.Range(0, 2);
					if(chance == 1)
					{
						strongest = possible_weapons[i];
					}
				}
			}

			Buff new_buff = Instantiate(buff, strongest.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.damage_buff = -amount;
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.AddBuff();
		}
    }

    public Buff CheckIfDebuffExists(Transform weapon)
    {
        for(int i = 0; i < weapon.childCount; i++)
        {
            if(weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
            {
                return weapon.GetChild(i).GetComponent<Buff>();
            }
        }
        return null;
    }

	public void RemoveBuffs()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			GameObject buff = weapons[i].GetCertainBuff(GetComponent<Weapon>().name);
			if(buff != null)
			{
				buff.GetComponent<Buff>().RemoveBuff();
				Destroy(buff);
			}
		}
	}
}
