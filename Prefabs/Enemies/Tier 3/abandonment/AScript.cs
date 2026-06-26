using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AScript : MonoBehaviour
{
    List<Weapon> learned = new List<Weapon>();
	int previous_x = 0;

	void Awake()
	{
		//GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().onDestruction = true;
		GetComponent<BuffController>().destructive = true;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special = Benefit;
	}

	public void Benefit(Weapon w)
	{
		int x = Random.Range(1, 4);
		if(x == previous_x)
		{
			x = Random.Range(1, 4);
		}
		previous_x = x;
		x = 3;
		switch(x)
		{
			case 1:
				MakeStronger(w);
				break;
			case 2:
				DealDamage(w);
				break;
			case 3:
				HealOrGiveArmor(w);
				break;
			
		}
	}

	public void MakeStronger(Weapon w)
	{
		List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
		int x = Random.Range(0, weapons.Count);
		if(weapons.Count > 1)
		{
			while(w == weapons[x])
			{
				x = Random.Range(0, weapons.Count);
			}	
		}
		weapons[x].GetComponent<Weapon>().damage++;
	}

	public void DealDamage(Weapon w)
	{
		GetComponent<EffectDamage>().DealDamage(w);
	}

	public void HealOrGiveArmor(Weapon w)
	{
		if(GetComponent<Weapon>().player_owner.HB.GiveCurrentHealth() < GetComponent<Weapon>().player_owner.HB.GiveMaxHealth())
		{
			GetComponent<Healing>().Heal();
		} else
		{
			List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				Buff new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[i].transform).GetComponent<Buff>();
				new_buff.id = GetComponent<Weapon>().name + "_buff";
				new_buff.armor_buff = 2;
				new_buff.temporary = true;
				new_buff.timer = 5;
				new_buff.AddBuff();
			}
		}
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
