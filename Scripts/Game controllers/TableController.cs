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

        HandleDamage();
        HandleHealing();

        player.GetComponent<PlayerContoller>().Death();

        player.GetComponent<PlayerContoller>().HB.damage_taken = false;
        enemy.GetComponent<EnemyController>().HB.damage_taken = false;

        MC.playerChoise.GetComponent<Weapon>().CheckUp();
        MC.enemyChoise.GetComponent<Weapon>().CheckUp();

        //New battle mechanics
        enemy.transform.GetChild(0).GetComponent<BasicEnemy>().SelectWeaponPair();
        enemy.transform.GetChild(0).GetComponent<BasicEnemy>().TelegraphWeaponPair();

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
                player.GetComponent<PlayerContoller>().HB.TakeDamage(player_damage);
            }
            player_damage = 0;
        } else
        {
            MC.playerChoise.takeNoDamage.Invoke();
        }


        if(enemy_damage > 0)
        {
            if(!enemy.GetComponent<EnemyController>().HB.dead)
            {
                enemy.GetComponent<EnemyController>().HB.TakeDamage(enemy_damage);
            }
            enemy_damage = 0;
        } else
        {
            MC.enemyChoise.takeNoDamage.Invoke();
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
}
