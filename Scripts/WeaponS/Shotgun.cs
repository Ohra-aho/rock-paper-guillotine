using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
	int previous = 5;
    public void Activate()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder");

        enemy.GetComponent<EnemyController>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        enemy.GetComponent<EnemyController>().dead = enemy.GetComponent<EnemyController>().HB.CheckIfDead();
        GetComponent<Weapon>().deal_effect_damage.Invoke();
		int rand = Random.Range(0, 4);
		if(previous == 0 && rand == 0)
		{
			rand = Random.Range(0, 4);
		}
		if(rand == 0)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        	GetComponent<Weapon>().takeDamage.Invoke();	
		}
		previous = rand;
    }
}
