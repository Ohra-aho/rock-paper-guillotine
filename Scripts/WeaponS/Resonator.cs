using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resonator : MonoBehaviour
{
	bool activated = false;
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special = ReTriggerEffect;
		GetComponent<BuffController>().endPhase = true;
	}

	public void ReTriggerEffect(Weapon w)
	{
		if(!activated)
		{
			activated = true;
			w.endPhase.Invoke();
		} else
		{
			activated = false;
		}
	}
}
