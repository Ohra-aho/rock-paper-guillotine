using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Networking.PlayerConnection;

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
    [HideInInspector] public int player_direct_damage = 0;
    [HideInInspector] public int enemy_damage = 0;
    [HideInInspector] public int enemy_direct_damage = 0;
    [HideInInspector] public int player_healing = 0;
    [HideInInspector] public int enemy_healing = 0;
	[HideInInspector] public int health_increase = 0;
	[HideInInspector] public int health_decrease = 0;
	[HideInInspector] public int player_armor = 0;
	[HideInInspector] public int enemy_armor = 0;

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

		player_armor = MC.playerChoise.GiveEffectiveArmor();
		enemy_armor = MC.enemyChoise.GiveEffectiveArmor();

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
		int true_damage = player_damage - player_armor;
		if(true_damage < 0) true_damage = 0;
		if(true_damage + player_direct_damage > 0)
			player.GetComponent<PlayerContoller>().HB.LowHealthReaction();
		player_damage = 0;
		player_direct_damage = 0;

		player.GetComponent<PlayerContoller>().HB.dead = player.GetComponent<PlayerContoller>().HB.CheckIfDead();

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
        if(player_damage > 0 || player_direct_damage > 0)
        {
            if(!player.GetComponent<PlayerContoller>().HB.dead)
            {
				int true_damage = player_damage - player_armor;
				if(true_damage < 0) true_damage = 0;

				if(true_damage + player_direct_damage > 0)
				{
					player.GetComponent<PlayerContoller>().HB.TakeDamage(true_damage + player_direct_damage);
					MC.playerChoise.takeDamage.Invoke();
					MC.enemyChoise.dealDamage.Invoke();	

					//Achievements
					if(MC.first_turn) MC.GetComponent<RLController>().CheckForSlow();
				}
            }
        }

        if(enemy_damage > 0 || enemy_direct_damage > 0)
        {
            if(!enemy.GetComponent<EnemyController>().HB.dead)
            {
				int true_damage = enemy_damage - enemy_armor;
				if(true_damage < 0) true_damage = 0;
				if(true_damage + enemy_direct_damage > 0)
				{
					enemy.GetComponent<EnemyController>().HB.TakeDamage(true_damage + enemy_direct_damage);
					MC.enemyChoise.takeDamage.Invoke();
					MC.playerChoise.dealDamage.Invoke();

					//Achievements
					if(enemy_damage + enemy_direct_damage >= 5) MC.GetComponent<RLController>().CheckForSlautherer(); 	 
					MC.GetComponent<RLController>().CheckForRelentless(true);
				}
            }
           	enemy_damage = 0;
			enemy_direct_damage = 0;
			enemy.GetComponent<EnemyController>().HB.dead = enemy.GetComponent<EnemyController>().HB.CheckIfDead();
        }
		else
		{
			MC.GetComponent<RLController>().CheckForRelentless(false);
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
