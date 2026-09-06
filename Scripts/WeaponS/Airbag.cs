using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : MonoBehaviour
{
	bool triggered = false;
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().takeDamage = true;
		GetComponent<BuffController>().special = Cushion;
	}

	public void Cushion(Weapon w)
    {
        int current_health = w.player_owner.GetComponent<PlayerContoller>().HB.GiveCurrentHealth();
        if (current_health == 1 && !triggered)
        {
			GetComponent<Healing>().ForcedHeal();
			GetComponent<Weapon>().heal.Invoke();
			Buff own_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
			own_buff.temporary = true;
			own_buff.timer = 1000;
			own_buff.reminder = "Has already triggered.";
			triggered = true;
        }
    }

	public void ResetTrigger()
	{
		triggered = false;
	}
}
