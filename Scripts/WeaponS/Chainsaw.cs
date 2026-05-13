using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public void UseFuel()
	{
		GetComponent<Stacking>().DecreaseStacks(1);
	}

	public void ChangeType()
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Weapon>().type = MainController.Choise.voittamaton;
		} else
		{
			GetComponent<Weapon>().type = MainController.Choise.sakset;
		}
	}
}
