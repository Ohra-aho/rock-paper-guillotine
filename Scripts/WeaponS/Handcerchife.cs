using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handcerchife : MonoBehaviour
{
    public void IncreaseStack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		int amount = player.GetComponent<PlayerContoller>().HB.GiveMaxHealth() - player.GetComponent<PlayerContoller>().GiveCurrentHealth();
		if(amount > 0) GetComponent<Stacking>().IncreaseStacks(amount);
        if(GetComponent<Stacking>().stacks >= 4)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }

	public void UseStacks()
	{
		if(GetComponent<Stacking>().stacks >= 4)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<EffectDamage>().DealDamage(null);
        }
	}
}
