using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    public int amount;
    public bool armor_piercing;
    public void DealDamage(Weapon weapon)
    {
		Debug.Log("QUE");
        if (weapon != null)
        {
            weapon.EffectDamage(GetEffectiveDamage());
			weapon.deal_effect_damage.Invoke();
        }
        else
        {
            GetComponent<Weapon>().EffectDamage(GetEffectiveDamage());
			GetComponent<Weapon>().deal_effect_damage.Invoke();
        }
    }

    public void SelfDamage(Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.SelfDamage(GetEffectiveDamage());
			weapon.deal_effect_damage.Invoke();
        }
        else
        {
            GetComponent<Weapon>().SelfDamage(GetEffectiveDamage());
			GetComponent<Weapon>().deal_effect_damage.Invoke();
        }
    }

    public void DealSetDamage(int amount)
    {
        GetComponent<Weapon>().EffectDamage(amount + GetDamageBuff());
		GetComponent<Weapon>().deal_effect_damage.Invoke();
    }

    public void SetSelfDamage(int amount)
    {
        GetComponent<Weapon>().SelfDamage(amount + GetDamageBuff());
    }

	public void ForcedDamage()
	{
		if(GetComponent<Weapon>().player)
		{
			GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.TakeDamage(GetEffectiveDamage());
		}
	}

	private int GetEffectiveDamage()
	{
		int true_amount = amount;
		for(int i = 0; i < transform.childCount; i++)
		{
			true_amount += transform.GetChild(i).GetComponent<Buff>().effect_damage_buff;
			Debug.Log(transform.GetChild(i).GetComponent<Buff>().effect_damage_buff);
		}
		return true_amount;
	}

	private int GetDamageBuff()
	{
		int true_amount = 0;
		for(int i = 0; i < transform.childCount; i++)
		{
			true_amount += transform.GetChild(i).GetComponent<Buff>().effect_damage_buff;
		}
		return true_amount;
	}
}
