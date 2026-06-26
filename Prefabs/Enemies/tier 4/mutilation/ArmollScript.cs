using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmollScript : MonoBehaviour
{
    bool decreased = false;

	public void DecreaseHealth()
    {
        if(!decreased)
        {
            GetComponent<HealthIncrease>().ForceHealthDecrease();
            decreased = true;
        }
    }

	public void IncreaseHealth()
	{
		if(decreased)
        {
            GetComponent<HealthIncrease>().ForceHealthIncrease();
            decreased = false;
        }
	}
}
