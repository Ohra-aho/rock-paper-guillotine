using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
	bool used = false;
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuff()
	{
		GameObject buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		if(buff == null)
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name;
			new_buff.damage_buff = 1;
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.AddBuff();	
		} else
		{
			buff.GetComponent<Buff>().damage_buff += 1;
		}
	}

	public void Use()
	{
		used = true;
	}

	public void NotUsed()
	{
		if(!used)
		{
			GameObject buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
			if(buff != null)
			{
				buff.GetComponent<Buff>().damage_buff -= 1;
			}
		}
		used = false;
	}
}
