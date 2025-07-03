using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [HideInInspector] public bool first;

    [HideInInspector] public bool? won;
    //[HideInInspector] public bool dead;
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
    public GameObject story_event_holder;

    [HideInInspector] public bool firstRewardMenu = false;

    public List<GameObject> playthroughts;

     public bool buttons_active = true;

    public int reward_tier = 1;

    public enum Choise
    {
        kivi,
        paperi,
        sakset,
        voittamaton,
        hyödytön
    }

    public enum State
    {
        in_battle,
        re_arming,
        transition,
        reward,
        idle,
        dialog,
        dead,
        stalling
    }

    public State game_state = State.idle;

    private void Start()
    {
        first = true;
        if (first) {
           // GetComponent<StoryController>().events.AddRange(playthroughts[0].GetComponent<Story>().events); 
        }
    }

    private void Update()
    {
        GetComponent<StoryController>().InvokeNextEvent();
    }

    public void SetNewState(State new_state)
    {
        if(game_state != State.dead)
        {
            game_state = new_state;
            //Debug.Log(game_state);
        }
    }

    public bool CompareState(State state)
    {
        return game_state == state;
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
                    case Choise.hyödytön: won = true; break;
                    case Choise.voittamaton: won = false; break;
                }
                break;
            case Choise.paperi:
                switch (enemyChoise.type)
                {
                    case Choise.kivi: won = true; break;
                    case Choise.paperi: won = null; break;
                    case Choise.sakset: won = false; break;
                    case Choise.hyödytön: won = true; break;
                    case Choise.voittamaton: won = false; break;
                }
                break;
            case Choise.sakset:
                switch (enemyChoise.type)
                {
                    case Choise.kivi: won = false; break;
                    case Choise.paperi: won = true; break;
                    case Choise.sakset: won = null; break;
                    case Choise.hyödytön: won = true; break;
                    case Choise.voittamaton: won = false; break;
                }
                break;
            case Choise.voittamaton:
                if(enemyChoise.type != Choise.voittamaton)
                {
                    won = true;
                } else
                {
                    won = null;
                }
                break;
            case Choise.hyödytön:
                if (enemyChoise.type != Choise.hyödytön)
                {
                    won = false;
                }
                else
                {
                    won = null;
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
        SetNewState(State.dead);
        GetComponent<StoryController>().playthroughts++;
        EndRound();
    }

    public void EndRound()
    {
        EnableObject(startButton);
        startButton.GetComponent<StartButton>().EndRound();
        if(game_state != State.dead)
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
        if(!story_event_holder.transform.GetChild(0).GetComponent<Encounter>().last) SpawnRewardMenu();
    }

    

    public void DisplayConsequenses(bool? result)
    {
        switch (result)
        {
            case true:
                enemyChoise.lose.Invoke();
                playerChoise.DealDamage(
                    enemyChoise
                    );
                break;
            case false:
                enemyChoise.win.Invoke();
                enemyChoise.DealDamage(
                    playerChoise
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
