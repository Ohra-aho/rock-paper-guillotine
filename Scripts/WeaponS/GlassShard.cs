using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShard : MonoBehaviour
{
    private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.type == MainController.Choise.sakset && w != GetComponent<Weapon>(); };
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().special = (Weapon w) =>
		{
			if(!GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
			{
				Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
				new_buff.type_change = MainController.Choise.voittamaton;
				new_buff.temporary = true;
				new_buff.timer = 2;
				new_buff.destructive = true;
				new_buff.visible_buff = true;
				new_buff.reminder = "After use, self-destructs.";
				new_buff.AddBuff();	
			}
		};
	}
}
