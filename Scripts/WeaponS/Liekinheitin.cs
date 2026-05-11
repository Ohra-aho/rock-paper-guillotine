using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liekinheitin : MonoBehaviour
{
	public GameObject buff;
    public void DealDamageFromArmor()
    {
        GetComponent<EffectDamage>().amount += GetComponent<Weapon>().opponent.armor * 2;
        GetComponent<EffectDamage>().DealDamage(null);
        GetComponent<EffectDamage>().amount -= GetComponent<Weapon>().opponent.armor * 2;
    }

	public void BlazeOpponent()
	{
		if(!GetComponent<Weapon>().opponent.GetCertainBuff(GetComponent<Weapon>().name))
		{
			Buff new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform).GetComponent<Buff>();
			new_buff.timer = 5;
			new_buff.temporary = true;
			new_buff.resultPhase = true;
			new_buff.special = (Weapon w) => { GetComponent<EffectDamage>().SelfDamage(w); };
			new_buff.AddBuff();	
		}
	}
}
