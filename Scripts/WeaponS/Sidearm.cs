using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidearm : MonoBehaviour
{
    public void Fire() {
		if(GetComponent<Stacking>().stacks > 0) {
			GetComponent<Stacking>().DecreaseStacks(1);
			GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
		}
	}

	public void GivePointsAway() {
		if(GetComponent<Stacking>().stacks > 0) {
			GetComponent<Stacking>().DecreaseStacks(1);
			List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
			List<Weapon> valid_targets = new List<Weapon>();
			for(int i = 0; i < weapons.Count; i++) {
				if(weapons[i].GetComponent<Stacking>() && weapons[i].name != GetComponent<Weapon>().name) {
					valid_targets.Add(weapons[i]);
				}
			}
			if(valid_targets.Count > 0) {
				int index = Random.Range(0, valid_targets.Count);
				valid_targets[index].GetComponent<Stacking>().IncreaseStacks(1);
			}
		}
	}

	public void GainStartingPoint() {
		if(GetComponent<Stacking>().stacks < 1) {
			GetComponent<Stacking>().IncreaseStacks(1);
		}
	}
}
