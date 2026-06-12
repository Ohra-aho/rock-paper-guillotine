using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    [HideInInspector] public int resultsVisible = 0;
    bool resulting = false;
    bool? result = false;

    MainController MC;
    Coroutine table;

    [HideInInspector] public int player_damage = 0;
    [HideInInspector] public int enemy_damage = 0;
    [HideInInspector] public int player_healing = 0;
    [HideInInspector] public int enemy_healing = 0;
	[HideInInspector] public int health_increase = 0;
	[HideInInspector] public int health_decrease = 0;

    private void Update()
    {
        table = null;
        if (resultsVisible > 0 && !resulting)
        {
            if(resultsVisible == 2)
            {
                resulting = true;
                table = StartCoroutine(DisplayAll());
            }
        }
    }

    public void ClearDisplay()
    {
        resultsVisible = 0;
        resulting = false;
    }

    public void CallDisplay(bool? r)
    {
        result = r;
    }

    IEnumerator DisplayAll() {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();

        yield return new WaitForSeconds(0.2f);
        MC.DisplayConsequenses(result);

        //Might need something...
        player.GetComponent<PlayerContoller>().ResultPhase();
        enemy.GetComponent<EnemyController>().ResultPhase();

        player.GetComponent<PlayerContoller>().EndPhase();
        enemy.GetComponent<EnemyController>().EndPhase();

        ActivateEachTurnEffects(GameObject.FindGameObjectWithTag("RI"));
        ActivateEachTurnEffects(GameObject.FindGameObjectWithTag("RIE"));

        if(player_damage <= 0) MC.playerChoise.takeNoDamage.Invoke();
        if(enemy_damage <= 0) MC.enemyChoise.takeNoDamage.Invoke();

        HandleDamage();
        HandleHealing();

		HandleHealthDecrease();
		HandleHealthIncrease();
		player.GetComponent<PlayerContoller>().HB.LowHealthReaction();

        player.GetComponent<PlayerContoller>().HB.damage_taken = false;
        enemy.GetComponent<EnemyController>().HB.damage_taken = false;

        MC.playerChoise.GetComponent<Weapon>().CheckUp();
        MC.enemyChoise.GetComponent<Weapon>().CheckUp();

        //New battle mechanics
        //enemy.transform.GetChild(0).GetComponent<BasicEnemy>().SelectWeaponPair();
		if(!MC.victory)
		{
			enemy.transform.GetChild(0).GetComponent<BasicEnemy>().StikToPlan();
        	enemy.transform.GetChild(0).GetComponent<BasicEnemy>().TelegraphWeaponPair();
		} else
		{
			GameObject.Find("enemy weapon rack").GetComponent<WeaponInfoRack>().ResetTelegraphs();
		}
        

        if (table != null) StopCoroutine(table);
    }

    private void ActivateEachTurnEffects(GameObject weapon_holder)
    {
        for(int i = 0; i < weapon_holder.transform.childCount; i++)
        {
            if(weapon_holder.transform.GetChild(i).GetComponent<Weapon>().eachTurn != null)
            {
                weapon_holder.transform.GetChild(i).GetComponent<Weapon>().eachTurn.Invoke();
            }
        }
    }

    private void HandleDamage()
    {
        if(player_damage > 0)
        {
            if(!player.GetComponent<PlayerContoller>().HB.dead)
            {
				if(MC.enemyChoise.penetrating)
				{
                	player.GetComponent<PlayerContoller>().HB.TakeDamage(player_damage);
					MC.playerChoise.takeDamage.Invoke();
					MC.enemyChoise.dealDamage.Invoke();	
				} else
				{
					if(player_damage - MC.playerChoise.GiveEffectiveArmor() > 0)
					{
						player.GetComponent<PlayerContoller>().HB.TakeDamage(player_damage - MC.playerChoise.GiveEffectiveArmor());
						MC.playerChoise.takeDamage.Invoke();
						MC.enemyChoise.dealDamage.Invoke();	
					}
				}
            }
            player_damage = 0;
			player.GetComponent<PlayerContoller>().HB.dead = player.GetComponent<PlayerContoller>().HB.CheckIfDead();
        }


        if(enemy_damage > 0)
        {
            if(!enemy.GetComponent<EnemyController>().HB.dead)
            {
				if(MC.playerChoise.penetrating)
				{
					enemy.GetComponent<EnemyController>().HB.TakeDamage(enemy_damage);
					MC.enemyChoise.takeDamage.Invoke();
					MC.playerChoise.dealDamage.Invoke();
				} else
				{
					if(enemy_damage - MC.enemyChoise.GiveEffectiveArmor() > 0)
					{
						enemy.GetComponent<EnemyController>().HB.TakeDamage(enemy_damage - MC.enemyChoise.GiveEffectiveArmor());
						MC.enemyChoise.takeDamage.Invoke();
						MC.playerChoise.dealDamage.Invoke();
					}
				}
                
            }
            enemy_damage = 0;
			enemy.GetComponent<EnemyController>().HB.dead = enemy.GetComponent<EnemyController>().HB.CheckIfDead();
        }
    }

    private void HandleHealing()
    {
        if (player_healing > 0)
        {
            if (!player.GetComponent<PlayerContoller>().HB.dead)
            {
                player.GetComponent<PlayerContoller>().HB.HealDamage(player_healing);
            }
            player_healing = 0;
        }
        if (enemy_healing > 0)
        {
            if (!enemy.GetComponent<EnemyController>().HB.dead)
            {
                enemy.GetComponent<EnemyController>().HB.HealDamage(enemy_healing);
            }
            enemy_healing = 0;
        }
    }

	private void HandleHealthIncrease()
	{
		if(health_increase > 0) player.GetComponent<PlayerContoller>().HB.IncreaseHealthBar(health_increase, true);
		health_increase = 0;
	}

	private void HandleHealthDecrease()
	{
		if(health_decrease > 0) player.GetComponent<PlayerContoller>().HB.DecreaseHealthBar(health_decrease, true);
		health_decrease = 0;
	}
}
