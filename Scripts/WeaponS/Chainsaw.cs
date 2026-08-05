using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
	public GameObject buff;
	void Awake()
	{
		ChangeType();
	}
	public void UseFuel()
	{
		GetComponent<Stacking>().DecreaseStacks(1);
	}

	public void ChangeType()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			if(!GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
			{
				Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
				new_buff.type_change = MainController.Choise.voittamaton;
				new_buff.id = GetComponent<Weapon>().name;
			} else
			{
				GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>().type_change = MainController.Choise.voittamaton;
			}
		} else
		{
			if(GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
			{
				Destroy(GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name));
			}
		}
	}
}
