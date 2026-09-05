using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCode : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().special = (Weapon w) =>
		{
			Buff old_buff = w.GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>();
			old_buff.RemoveBuff();
			old_buff.type_change = MainController.Choise.useless;
			old_buff.timer = 1000;
			old_buff.reminder = "Made useless until the end of the fight.";
			old_buff.AddBuff();
		};
		GetComponent<BuffController>().reminder = "After use, become \"useless\" for the rest of the fight.";
 	}
}
