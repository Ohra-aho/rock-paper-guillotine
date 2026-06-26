using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().armor_bonus = 2;
		GetComponent<BuffController>().until_used = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().reminder = "+2 armor until used.";
	}
}
