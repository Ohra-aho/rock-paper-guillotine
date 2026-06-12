using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseDamage;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == GetComponent<Weapon>().name; };
        GetComponent<BuffController>().each_turn = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 3;
		GetComponent<BuffController>().special_apply = true;
    }

    public void IncreaseDamage(Weapon w)
    {
        GetComponent<Stacking>().DecreaseStacks(1);
		if(GetComponent<Stacking>().stacks == 0)
		{
			GetComponent<EffectDamage>().DealDamage(GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise);
		}
    }

	public void Activate()
	{
		if(!GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
		{
			GetComponent<Stacking>().stacks = 3;
			GetComponent<BuffController>().Equip();
		}
	}

	public void EmptyStack()
	{
			GetComponent<Stacking>().stacks = 0;
	}
}
