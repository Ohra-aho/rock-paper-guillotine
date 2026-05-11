using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiidenkivi : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().damage_bonus = 2;
		GetComponent<BuffController>().special_apply = true;
	}
}
