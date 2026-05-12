using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handcerchife : MonoBehaviour
{
    public void IncreaseStack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Stacking>().IncreaseStacks(player.GetComponent<PlayerContoller>().HB.GiveMaxHealth() - player.GetComponent<PlayerContoller>().GiveCurrentHealth());
        if(GetComponent<Stacking>().stacks >= 6)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }

	public void UseStacks()
	{
		if(GetComponent<Stacking>().stacks >= 6)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<EffectDamage>().DealDamage(null);
        }
	}
}
