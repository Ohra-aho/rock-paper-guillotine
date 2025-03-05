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


    private TableController TC;

    public GameObject playerSide;
    public GameObject enemySide;

    public Choise playerChoise;
    public Choise enemyChoise;

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

    private void Start()
    {
        
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
        switch(playerChoise)
        {
            case Choise.kivi:
                switch(enemyChoise)
                {
                    case Choise.kivi: won = null; break;
                    case Choise.paperi: won = false; break;
                    case Choise.sakset: won = true; break;
                }
                break;
            case Choise.paperi:
                switch (enemyChoise)
                {
                    case Choise.kivi: won = true; break;
                    case Choise.paperi: won = null; break;
                    case Choise.sakset: won = false; break;
                }
                break;
            case Choise.sakset:
                switch (enemyChoise)
                {
                    case Choise.kivi: won = false; break;
                    case Choise.paperi: won = true; break;
                    case Choise.sakset: won = null; break;
                }
                break;
        }
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
        EndRound();
        dead = true;
    }

    public void EndRound()
    {
        EnableObject(startButton);
        startButton.GetComponent<StartButton>().EndRound();
        GameObject.Find("Story Event Holder").transform.GetChild(0).GetComponent<StoryEvent>().Procceed();
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
                player.GetComponent<PlayerContoller>()
                    .DealDamage(
                        player.GetComponent<PlayerContoller>().damage
                     );
                break;
            case false:
                player.GetComponent<PlayerContoller>()
                    .TakeDamage(
                        enemy.GetComponent<EnemyController>().damage
                    );
                break;
            case null:
                player.GetComponent<PlayerContoller>().Draw();
                break;
        }
    }

    public void SpawnRewardMenu()
    {
        Instantiate(rewardMenu, rewardmenuHolder.transform);
    }
}
