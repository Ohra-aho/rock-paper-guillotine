using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().special = GainStack;
    }

    public void GainStack(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
       
    }

	public void SetType()
	{
		Debug.Log(GetComponent<Stacking>().stacks);
		if(GetComponent<Stacking>().stacks >= 3)
        {
			if(!GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name + "_2"))
			{
				Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
				new_buff.id = GetComponent<Weapon>().name + "_2";
				new_buff.type_change = MainController.Choise.voittamaton;
				new_buff.AddBuff();
			} else
			{
				GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_2").GetComponent<Buff>().type_change = MainController.Choise.voittamaton;
			}
        }
	}

    public void UseStaks()
    {
        if(
			GetComponent<Weapon>().GiveEffectiveType() == MainController.Choise.voittamaton && 
			GameObject.Find("EventSystem").GetComponent<MainController>().won != false
		)
		{
			GetComponent<Stacking>().DecreaseStacks(1);	
		}
		
        if (GetComponent<Stacking>().stacks < 3)
        {
			if(GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name + "_2"))
			{
				Destroy(GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name + "_2"));
			}
        }
    }
}
