using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Veriterä : MonoBehaviour
{
    private void Awake()
    {
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().takeDamage = true;
		GetComponent<BuffController>().special = BuffThis;
    }

	public void BuffThis(Weapon w)
	{
		GameObject old_buff = GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name);
		if(old_buff != null)
		{
			old_buff.GetComponent<Buff>().damage_buff++;
		} else
		{
			Buff own_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
			own_buff.damage_buff = 1;
			own_buff.id = GetComponent<Weapon>().name;
		}
	}	


}
