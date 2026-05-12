using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyssy : MonoBehaviour
{
    public void DealDamage()
    {
        if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<EffectDamage>().DealDamage(null);
        	GetComponent<Stacking>().DecreaseStacks(1);
		}
    }
}
