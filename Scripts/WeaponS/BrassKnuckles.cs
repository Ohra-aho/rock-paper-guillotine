using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassKnuckles : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().draw_winner = true;
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "Wins draws.";
 	}
}
