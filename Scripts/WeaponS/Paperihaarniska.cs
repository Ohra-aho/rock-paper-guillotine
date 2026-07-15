using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperihaarniska : MonoBehaviour
{
	public GameObject buff;

	void Awake()
	{
		Buff own_buff = Instantiate(buff, transform).GetComponent<Buff>();
		own_buff.armor_buff = GetComponent<Stacking>().stacks;
		own_buff.id = GetComponent<Weapon>().name;
	}

	public void IncreaseStack()
    {
		GetComponent<Stacking>().DecreaseStacks(1);
		if(GetComponent<Stacking>().stacks == 0)
		{
            GetComponent<SelfDestruct>().Destruct();
		}
    }

	public void CalculateArmor()
	{
		GameObject own_buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		if(own_buff != null)
		{
			own_buff.GetComponent<Buff>().armor_buff = GetComponent<Stacking>().stacks;	
		} else
		{
			
			Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
			new_buff.armor_buff = GetComponent<Stacking>().stacks;
			new_buff.id = GetComponent<Weapon>().name;
		}
	}
}
