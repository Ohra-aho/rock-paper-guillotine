using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [HideInInspector] public bool? won;
    [HideInInspector] public bool dead;
    [HideInInspector] public bool endTriggered;
    public bool stop;

    public TableController TC;

    public Weapon playerChoise;
    public Weapon enemyChoise;

    public GameObject player;
    public GameObject enemy;

    public GameObject enemyHolder;

    public GameObject startButton;
    public GameObject rewardmenuHolder;
    public GameObject rewardMenu;

    public GameObject quilliotine;

    [HideInInspector] public bool firstRewardMenu = false;

    public enum Choise
    {
        kivi,
        paperi,
        sakset
    }

    private void Update()
    {
        if(dead)
        {
            if(startButton.GetComponent<StartButton>().sidesOutOfView && !endTriggered)
            {
                endTriggered = true;
                quilliotine.GetComponent<Test>().PlayAnimation("Lose");
            }
        } else
        {
            GetComponent<StoryController>().InvokeNextEvent();
        }
    }

    public void CompareChoises()
    {
        SetWeaponOpponents();
        switch(playerChoise.type)
        {
            case Choise.kivi:
                switch(enemyChoise.type)
                {
                    case Choise.kivi: won = null; break;
                    case Choise.paperi: won = false; break;
                    case Choise.sakset: won = true; break;
                }
                break;
            case Choise.paperi:
                switch (enemyChoise.type)
                {
                    case Choise.kivi: won = true; break;
                    case Choise.paperi: won = null; break;
                    case Choise.sakset: won = false; break;
                }
                break;
            case Choise.sakset:
                switch (enemyChoise.type)
                {
                    case Choise.kivi: won = false; break;
                    case Choise.paperi: won = true; break;
                    case Choise.sakset: won = null; break;
                }
                break;
        }
    }

    private void SetWeaponOpponents()
    {
        enemyChoise.opponent = playerChoise;
        playerChoise.opponent = enemyChoise;
    }

    public void Resolve()
    {
        TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
        CompareChoises();
        TC.ClearDisplay();
        TC.CallDisplay(won);
    }



    public void DisableObject(GameObject it)
    {
        it.SetActive(false);
    }

    public void EnableObject(GameObject it)
    {
        it.SetActive(true);
    }

    public void ResetPlayer()
    {
        player.GetComponent<PlayerContoller>().RecoverAllHealth();
    }

    public void EndGame()
    {
        dead = true;
        EndRound();
    }

    public void EndRound()
    {
        EnableObject(startButton);
        startButton.GetComponent<StartButton>().EndRound();
        if(!dead)
        {
            GameObject.Find("Story Event Holder").transform.GetChild(0).GetComponent<StoryEvent>().Procceed();
        }
    }

    public void GiveUp()
    {
        TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
        TC.ClearDisplay();
        EndGame();
    }

    public void Loose()
    {
        TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
        TC.ClearDisplay();
        EndGame();
    }

    public void Win()
    {
        TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
        TC.ClearDisplay();
        EndRound();
        SpawnRewardMenu();
    }

    

    public void DisplayConsequenses(bool? result)
    {
        switch (result)
        {
            case true:
                playerChoise.DealDamage(
                    player.GetComponent<PlayerContoller>().HB, 
                    enemyChoise, 
                    enemy.GetComponent<EnemyController>().HB
                    );
                break;
            case false:
                enemyChoise.DealDamage(
                    enemy.GetComponent<EnemyController>().HB,
                    playerChoise,
                    player.GetComponent<PlayerContoller>().HB
                    );
                break;
            case null:
                enemyChoise.HandleDraw();
                playerChoise.HandleDraw();
                break;
        }
    }

    public void SpawnRewardMenu()
    {
        Instantiate(rewardMenu, rewardmenuHolder.transform);
    }
}
