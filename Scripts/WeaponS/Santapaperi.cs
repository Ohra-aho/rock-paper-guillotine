using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santapaperi : MonoBehaviour
{
    public int damage_buff;

    public void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.kivi; };
		GetComponent<BuffController>().heal = true;
		GetComponent<BuffController>().special = BuffDamage;
		GetComponent<BuffController>().reminder = "On heal, +1 damage until the end of the fight.";
    }

	public void BuffDamage(Weapon w)
	{
		GameObject buff = w.GetCertainBuff(GetComponent<Weapon>().name + "_damage");
		if(buff == null)
		{
			Buff new_buff = Instantiate(GetComponent<BuffController>().buff, w.transform).GetComponent<Buff>();
			new_buff.damage_buff = 1;
			new_buff.temporary = true;
			new_buff.timer = 1000;
		} else
		{
			buff.GetComponent<Buff>().damage_buff++;
		}
	}


}
