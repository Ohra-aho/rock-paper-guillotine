using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
	void Awake()
	{
		if(GetComponent<BuffController>())
		{
			GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
			GetComponent<BuffController>().draw_winner = true;
			GetComponent<BuffController>().penetrating = true;
			GetComponent<BuffController>().temporary = true;
			GetComponent<BuffController>().timer = 2;
			GetComponent<BuffController>().special_apply = true;
		}
	}

	public void Rend()
	{
		GetComponent<Weapon>().damage += 1;
	}
}
