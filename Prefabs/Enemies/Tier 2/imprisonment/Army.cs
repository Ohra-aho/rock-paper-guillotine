using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
	public GameObject buff;
	bool disabled = false;

    public void Chain()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < weapons.Count; i++)
		{
			Buff new_buff = Instantiate(buff, weapons[i].transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.damage_buff = -1;
			new_buff.AddBuff();
		}
	}

	public void Jar()
	{
		if(!disabled)
		{
			List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
			int index = Random.Range(0, weapons.Count);
			
			Buff new_buff = Instantiate(buff, weapons[index].transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 2;
			new_buff.type_change = MainController.Choise.useless;
			new_buff.AddBuff();
		}
	}

	public void JarDisabled()
	{
		disabled = true;
	}
}
