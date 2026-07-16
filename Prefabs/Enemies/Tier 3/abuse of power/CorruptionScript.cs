using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionScript : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().destructive = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().special = Equipped;
	}

	public void Unequipped()
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
		int x = Random.Range(0, weapons.Count);
		Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[x].transform).GetComponent<Buff>();
		new_buff.id = GetComponent<Weapon>().name = "_debuff";
		new_buff.type_change = MainController.Choise.useless;
		new_buff.until_used = true;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
		new_buff.reminder = "Made useless.";
	}

	public void Equipped(Weapon w)
	{
		w.damage++;
		w.player_owner.GetComponent<PlayerInventory>().AddItem(Instantiate(w.gameObject));
	}
}
