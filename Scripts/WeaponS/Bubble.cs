using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public void ApplyBuff()
    {
        GetComponent<BuffController>().Equip();
    }

	public void IncreaseHealth() {
		if(GetComponent<HealthIncrease>().amount < 2 && !GetComponent<Weapon>().player_owner.HB.CheckIfDead() && !GetComponent<Weapon>().opponent.owner.HB.CheckIfDead()) {
			GetComponent<HealthIncrease>().GiveSetTemporaryHealth(1);
			GetComponent<HealthIncrease>().amount++;
		}
	}

	public void ResetHealth() {
		GetComponent<HealthIncrease>().RemoveTemporaryHealth();
		GetComponent<HealthIncrease>().amount = 0;
	}
}
