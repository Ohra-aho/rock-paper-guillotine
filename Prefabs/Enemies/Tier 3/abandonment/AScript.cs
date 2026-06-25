using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AScript : MonoBehaviour
{
    List<Weapon> learned = new List<Weapon>();

	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
		GetComponent<BuffController>().onDestruction = true;
		GetComponent<BuffController>().destructive = true;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special = Learn;
	}

	public void Learn(Weapon w)
	{
		/*if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Stacking>().DecreaseStacks(1);
			learned.Add(Instantiate(w));
			Weapon tw = learned[learned.Count - 1];
			GetComponent<Weapon>().first_turn.AddListener(() => { tw.first_turn.Invoke(); });
			GetComponent<Weapon>().end_of_fight.AddListener(() => { tw.end_of_fight.Invoke(); });
			GetComponent<Weapon>().choisePhase.AddListener(() => { tw.choisePhase.Invoke(); });
			GetComponent<Weapon>().resultPhase.AddListener(() => { tw.resultPhase.Invoke(); });
			GetComponent<Weapon>().endPhase.AddListener(() => { tw.endPhase.Invoke(); });
			GetComponent<Weapon>().victory.AddListener(() => { tw.victory.Invoke(); });
			GetComponent<Weapon>().takeDamage.AddListener(() => { tw.takeDamage.Invoke(); });
			GetComponent<Weapon>().dealDamage.AddListener(() => { tw.dealDamage.Invoke(); });
			GetComponent<Weapon>().deal_effect_damage.AddListener(() => { tw.deal_effect_damage.Invoke(); });
			GetComponent<Weapon>().takeNoDamage.AddListener(() => { tw.takeNoDamage.Invoke(); });
			GetComponent<Weapon>().win.AddListener(() => { tw.win.Invoke(); });
			GetComponent<Weapon>().lose.AddListener(() => { tw.lose.Invoke(); });
			GetComponent<Weapon>().draw.AddListener(() => { tw.draw.Invoke(); });
			GetComponent<Weapon>().heal.AddListener(() => { tw.heal.Invoke(); });
			GetComponent<Weapon>().gain_points.AddListener(() => { tw.gain_points.Invoke(); });
			GetComponent<Weapon>().equip.AddListener(() => { tw.equip.Invoke(); });
			GetComponent<Weapon>().unEquip.AddListener(() => { tw.unEquip.Invoke(); });
			GetComponent<Weapon>().constant.AddListener(() => { tw.constant.Invoke(); });
			GetComponent<Weapon>().onDestruction.AddListener(() => { tw.onDestruction.Invoke(); });
			GetComponent<Weapon>().eachTurn.AddListener(() => { tw.eachTurn.Invoke(); });
			GetComponent<Weapon>().unequipped.AddListener(() => { tw.unequipped.Invoke(); });
		}*/
	}
}
