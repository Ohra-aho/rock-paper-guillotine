using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int max = 4;
    int previous_damage = 0;

	private void Awake() {
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().damage_bonus = 0;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
	}

    public void RandomiceDamage()
    {
        int damage = Random.Range(0, max);
        GetComponent<BuffController>().damage_bonus = damage;
    }
}
