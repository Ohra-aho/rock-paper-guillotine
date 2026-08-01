using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
	private void Awake() {
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<Stacking>(); };
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().special = GivePoints;
		GetComponent<BuffController>().reminder = "After use, gains 1 point.";
	}

    public void GivePoints(Weapon w)
    {
		w.GetComponent<Stacking>().IncreaseStacks(1);
    }
}
