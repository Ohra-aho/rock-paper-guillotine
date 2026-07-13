using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lippu : MonoBehaviour
{
    bool debuffed = false;

	void Awake()
	{
		GetComponent<BuffController>().damage_bonus = 1;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 1000;
		GetComponent<BuffController>().lose = true;
		GetComponent<BuffController>().special = (Weapon w) => { GetComponent<BuffController>().Unequip(); };
		GetComponent<BuffController>().reminder = "+1 damage until you lose with any weapon.";
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().special_apply = true;
	}
}
