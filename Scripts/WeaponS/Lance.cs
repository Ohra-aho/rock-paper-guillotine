using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{
	bool buff_on = false;
    public void BuffSelf()
	{
		GetComponent<Weapon>().damage++;
		buff_on = true;
	}

	public void DebuffSelf()
	{
		if(buff_on)
		{
			GetComponent<Weapon>().damage--;
			if(GetComponent<Weapon>().damage < 0)
			{
				GetComponent<Weapon>().damage = 0;
			}
			buff_on = false;
		}
	}

	public void DealDamage()
	{
		if(buff_on)
		{
			GetComponent<EffectDamage>().DealDamage(null);
		}
	}
}
