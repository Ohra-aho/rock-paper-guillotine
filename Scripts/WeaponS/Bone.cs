using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public void ChangeHealingToDamage() {
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		GetComponent<EffectDamage>().amount = TC.player_healing;
		GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		TC.player_healing = 0;
		GetComponent<EffectDamage>().amount = 0;
	}
}
