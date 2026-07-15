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
    [HideInInspector] public int player_direct_damage = 0;
    [HideInInspector] public int enemy_damage = 0;
    [HideInInspector] public int enemy_direct_damage = 0;
    [HideInInspector] public int player_healing = 0;
    [HideInInspector] public int enemy_healing = 0;
	[HideInInspector] public int health_increase = 0;
	[HideInInspector] public int health_decrease = 0;
	[HideInInspector] public int player_armor = 0;
	[HideInInspector] public int enemy_armor = 0;

	void Awake()
	{
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
	}

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

        yield return new WaitForSeconds(0.2f);
        MC.DisplayConsequenses(result);

        player.GetComponent<PlayerContoller>().ResultPhase();
        enemy.GetComponent<EnemyController>().ResultPhase();

        player.GetComponent<PlayerContoller>().EndPhase();
        enemy.GetComponent<EnemyController>().EndPhase();

		List<Weapon> player_weapons = player.GetComponent<PlayerContoller>().GetWeapons();
		List<Weapon> enemy_weapons = enemy.GetComponent<EnemyController>().GetWeapons();
        ActivateEachTurnEffects(player_weapons);
        ActivateEachTurnEffects(enemy_weapons);

		player_armor = MC.playerChoise.GiveEffectiveArmor();
		enemy_armor = MC.enemyChoise.GiveEffectiveArmor();
		Debug.Log("Enemy armor 1:" + enemy_armor);

        if(GiveEffectivePlayerDamage() <= 0) MC.playerChoise.takeNoDamage.Invoke();
        if(GiveEffectiveEnemyDamage() <= 0) MC.enemyChoise.takeNoDamage.Invoke();

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

		MC.first_turn = false;

        //New battle mechanics
		if(!MC.victory)
		{
			enemy.transform.GetChild(0).GetComponent<BasicEnemy>().StikToPlan();
        	enemy.transform.GetChild(0).GetComponent<BasicEnemy>().TelegraphWeaponPair();
		} else
		{
			GameObject.Find("enemy weapon rack").GetComponent<WeaponInfoRack>().TrueReset();
		}
        
        if (table != null) StopCoroutine(table);
    }

	public void ApplyModifiers(List<Weapon> weapons)
	{
		for(int i = 0; i < weapons.Count; i++)
        {
			if(weapons[i].heal_modifier.GetPersistentEventCount() > 0)
			{
				weapons[i].heal_modifier.Invoke();
			}

			if(weapons[i].damage_modifier.GetPersistentEventCount() > 0)
			{
				weapons[i].damage_modifier.Invoke();
			}
		}
	}

    private void ActivateEachTurnEffects(List<Weapon> weapons)
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].eachTurn.GetPersistentEventCount() > 0)
            {
                weapons[i].eachTurn.Invoke();
            }
        }

		ApplyModifiers(weapons);
    }

    public void HandleDamage()
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
					if(MC.enemyChoise != null) MC.playerChoise.takeDamage.Invoke();
					if(MC.playerChoise != null) MC.enemyChoise.dealDamage.Invoke();	

					//Achievements
					if(MC.first_turn) MC.GetComponent<RLController>().CheckForSlow();
				}
            }
        }

        if(enemy_damage > 0 || enemy_direct_damage > 0)
        {
            if(!enemy.GetComponent<EnemyController>().HB.dead)
            {
				Debug.Log("Enemy armor 2: "+enemy_armor);
				int true_damage = enemy_damage - enemy_armor;
				if(true_damage < 0) true_damage = 0;
				if(true_damage + enemy_direct_damage > 0)
				{
					enemy.GetComponent<EnemyController>().HB.TakeDamage(true_damage + enemy_direct_damage);
					if(MC.enemyChoise != null) MC.enemyChoise.takeDamage.Invoke();
					if(MC.playerChoise != null) MC.playerChoise.dealDamage.Invoke();

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

    public void HandleHealing()
    {
        if (player_healing > 0)
        {
            if (!player.GetComponent<PlayerContoller>().HB.dead && player.GetComponent<PlayerContoller>().HB.GiveCurrentHealth() < player.GetComponent<PlayerContoller>().HB.GiveMaxHealth())
            {
                player.GetComponent<PlayerContoller>().HB.HealDamage(player_healing);
				MC.playerChoise.heal.Invoke();
            }
            player_healing = 0;
        }
        if (enemy_healing > 0)
        {
            if (!enemy.GetComponent<EnemyController>().HB.dead && enemy.GetComponent<EnemyController>().HB.GiveCurrentHealth() < enemy.GetComponent<EnemyController>().HB.GiveMaxHealth())
            {
                enemy.GetComponent<EnemyController>().HB.HealDamage(enemy_healing);
				MC.enemyChoise.heal.Invoke();
            }
            enemy_healing = 0;
        }
    }

	public void HandleHealthIncrease()
	{
		if(health_increase > 0) player.GetComponent<PlayerContoller>().HB.IncreaseHealthBar(health_increase, true);
		health_increase = 0;
	}

	public void HandleHealthDecrease()
	{
		if(health_decrease > 0) player.GetComponent<PlayerContoller>().HB.DecreaseHealthBar(health_decrease, true);
		health_decrease = 0;
	}

	public int GiveEffectivePlayerDamage()
	{
		int damage = player_damage - player_armor;
		if(damage < 0)
		{
			damage = 0;
		}
		damage += player_direct_damage;
		return damage;
	}

	public int GiveEffectiveEnemyDamage()
	{
		int damage = enemy_damage - enemy_armor;
		if(damage < 0)
		{
			damage = 0;
		}
		damage += enemy_direct_damage;
		return damage;
	}
}
