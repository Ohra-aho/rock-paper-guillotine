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
		if(GetComponent<HealthIncrease>().amount < 2) {
			GetComponent<HealthIncrease>().IncreaseSetAmount(1);
			GetComponent<HealthIncrease>().amount++;
		}
	}

	public void ResetHealth() {
		GetComponent<HealthIncrease>().RemoveTemporaryHealth();
		GetComponent<HealthIncrease>().amount = 0;
	}
}
