using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawBook : MonoBehaviour
{
    bool used = false;
	public GameObject buff;

	private void Awake() {
		GetComponent<Weapon>().special_token = () =>
		{
			if(used)
			{
				return 1;
			} else
			{
				return 0;
			}
		};
		GetComponent<Weapon>().load_special_token = () =>
		{
			if(GetComponent<Weapon>().token > 0)
			{
				used = true;
			}
		};
	}

    public void DefyDeath(Weapon w)
    {
        if (!GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name) && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.CheckIfDead())
        {
			TableController TC = GameObject.Find("Table").GetComponent<TableController>();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.dead = false;
			TC.player_damage = 0;
			TC.player_direct_damage = 0;
			TC.player_healing = 3;
            used = true;
			if(GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name) == null)
			{
				Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
				new_buff.reminder = "Won't save you anymore.";
				new_buff.id = GetComponent<Weapon>().name;
			}
        }
    }

	
}
