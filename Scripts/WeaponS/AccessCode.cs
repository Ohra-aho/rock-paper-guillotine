using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCode : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().penetrating = true;
		GetComponent<BuffController>().timer = 3;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "Pierces armor.";
 	}
}
