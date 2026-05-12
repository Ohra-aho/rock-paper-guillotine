using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().win = true;
		GetComponent<BuffController>().lose = true;
		GetComponent<BuffController>().special = ActivateBaseEffect;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special_apply= true;
	}

	public void ActivateBaseEffect(Weapon w)
	{
		switch(w.type)
		{
			case MainController.Choise.kivi:
				w.GetComponent<TypeEffects>().ActivateRock();
				break;
			case MainController.Choise.paperi:
				w.GetComponent<TypeEffects>().ActivatePaper();
				break;
			case MainController.Choise.sakset:
				w.GetComponent<TypeEffects>().ActivateScissors();
				break;
		}
	}
}
