using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    public void Wake()
	{
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		GetComponent<EffectDamage>().amount = 5 - weapons.Count;
		GetComponent<EffectDamage>().SelfDamage(GetComponent<Weapon>());
	}
}
