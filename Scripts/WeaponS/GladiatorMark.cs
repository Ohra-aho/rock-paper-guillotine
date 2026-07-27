using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorMark : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void DealDamage(Weapon w)
    {
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(TC.GiveEffectivePlayerDamage() > 0)
		{
			TC.player_damage++;
			GetComponent<Weapon>().deal_effect_damage.Invoke();
		}
		if(TC.GiveEffectiveEnemyDamage() > 0)
		{
			TC.enemy_damage++;
			GetComponent<Weapon>().deal_effect_damage.Invoke();
		}
    }
}
