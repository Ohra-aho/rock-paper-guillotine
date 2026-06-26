using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducktape : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "Can't be destroyed.";
	}
}
