using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
	public GameObject buff;
    public void Wake()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		GetComponent<EffectDamage>().amount = 5 - weapons.Count;
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}

	public void RandomNewType()
	{
		MainController.Choise type = GetComponent<Weapon>().opponent.type;

		GameObject existing_buff = GetComponent<Weapon>().opponent.GetCertainBuff(GetComponent<Weapon>().name);
		int prev_type = 1;
		switch(type)
		{
			case MainController.Choise.kivi: prev_type = 1; break;
			case MainController.Choise.paperi: prev_type = 2; break;
			case MainController.Choise.sakset: prev_type = 3; break;
			case MainController.Choise.useless: prev_type = 4; break;
			case MainController.Choise.voittamaton: prev_type = 5; break;
		}
		int new_type = Random.Range(1, 5);
		while(new_type == prev_type)
		{
			new_type = Random.Range(1, 5);
		}

		if(existing_buff != null)
		{
			existing_buff.GetComponent<Buff>().RemoveBuff();
			switch(new_type)
			{
				case 1: existing_buff.GetComponent<Buff>().type_change = MainController.Choise.kivi; break;
				case 2: existing_buff.GetComponent<Buff>().type_change = MainController.Choise.paperi; break;
				case 3: existing_buff.GetComponent<Buff>().type_change = MainController.Choise.sakset; break;
				case 4: existing_buff.GetComponent<Buff>().type_change = MainController.Choise.useless; break;
			}
			existing_buff.GetComponent<Buff>().AddBuff();		
		} else
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "Type changed until the end of the fight.";
			switch(new_type)
			{
				case 1: new_buff.type_change = MainController.Choise.kivi; break;
				case 2: new_buff.type_change = MainController.Choise.paperi; break;
				case 3: new_buff.type_change = MainController.Choise.sakset; break;
				case 4: new_buff.type_change = MainController.Choise.useless; break;
			}
			
			new_buff.AddBuff();		
		}
	}
}
