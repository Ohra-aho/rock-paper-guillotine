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

    BarkController BC;

    [HideInInspector] public bool firstRewardMenu = false;

    public List<GameObject> playthroughts;

    public bool buttons_active = true;

    public int reward_tier = 1;
    public bool rewards_disabled = false;

    public List<string> victory_barks;
    public GameObject victory_message;


    //Achievement aids
    [HideInInspector] public bool first_turn = true;

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
        any,
        in_battle,
        re_arming,
        transition,
        reward,
        idle,
        dialog,
        dead,
        stalling,
        pause
    }

    public State game_state = State.idle;

    private void Start()
    {
        first = true;
        if (first) {
           // GetComponent<StoryController>().events.AddRange(playthroughts[0].GetComponent<Story>().events); 
        }
        BC = GameObject.Find("BarkHolder").GetComponent<BarkController>();

        GetComponent<RLController>().Insiate();
        GetComponent<StoryController>().Inisiate();
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
                    case Choise.kivi: won = ChechDrawWinners(playerChoise, enemyChoise); break;
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
                    case Choise.paperi: won = ChechDrawWinners(playerChoise, enemyChoise); break;
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
                    case Choise.sakset: won = ChechDrawWinners(playerChoise, enemyChoise); break;
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
                    won = ChechDrawWinners(playerChoise, enemyChoise);
                }
                break;
            case Choise.hyödytön:
                if (enemyChoise.type != Choise.hyödytön)
                {
                    won = false;
                }
                else
                {
                    won = ChechDrawWinners(playerChoise, enemyChoise);
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

    private bool? ChechDrawWinners(Weapon player, Weapon enemy)
    {
        if((player.draw_winner && enemy.draw_winner) || (!player.draw_winner && !enemy.draw_winner))
        {
            return null;
        }
        if(player.draw_winner)
        {
            return true;
        }
        if(enemy.draw_winner)
        {
            return false;
        }
        return null;
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
        first_turn = true;
        SetNewState(State.dead);
        GetComponent<StoryController>().playthroughts++;
        EndRound();
    }

    public void EndRound()
    {
        first_turn = true;
        EnableObject(startButton);
        startButton.GetComponent<StartButton>().EndRound();

        if (game_state != State.dead)
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
        if (!GetComponent<StoryCheckList>().first_victory) GetComponent<StoryCheckList>().first_victory = true;
        //Achievement victory effects
        GetComponent<RLController>().ActivateWinEffects();

        TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
        TC.ClearDisplay();
        EndRound();
        GameObject.Find("Death Barks(Clone)").GetComponent<DeathBark>().IncreaseRounds();

        //Achievement checks
        GetComponent<RLController>().CHeckHPMaster();
        GetComponent<RLController>().CheckForSlautherer();
        GetComponent<RLController>().CheckForMadman();
        GetComponent<RLController>().CheckForTraditionalist();
        GetComponent<RLController>().CheckForRiskTaker();
        GetComponent<RLController>().CheckForPlotter();
        GetComponent<RLController>().CheckForSurvivor();
        GetComponent<RLController>().CheckForLucky();
        GetComponent<RLController>().unyielding_counter = 0;
        GameObject.Find("Reward reroll").GetComponent<RewardReroll>().used = false;

        if(
            !story_event_holder.transform.GetChild(0).GetComponent<Encounter>().last && 
            !player.GetComponent<PlayerContoller>().HB.dead && 
            !rewards_disabled
            ) SpawnRewardMenu();

        //Barks
        DisplayVictoryBark();

    }

    

    public void DisplayConsequenses(bool? result)
    {
        switch (result)
        {
            case true:
                if (playerChoise.draw_winner) playerChoise.draw.Invoke();
                enemyChoise.lose.Invoke();
                playerChoise.win.Invoke();
                playerChoise.DealDamage(
                    enemyChoise
                    );
                break;
            case false:
                if (enemyChoise.draw_winner) enemyChoise.draw.Invoke();
                enemyChoise.win.Invoke();
                playerChoise.lose.Invoke();
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


    //Barking

    public string GiveRandomBark(List<string> barks)
    {
        int index = Random.Range(0, barks.Count);
        return barks[index];
    }

    public void DisplayVictoryBark()
    {
        if(victory_message != null)
        {
            Instantiate(victory_message, story_event_holder.transform);
        }
        else if(victory_barks.Count > 0)
        {
            int chance = Random.Range(1, 4); //1, 4
            if (chance == 1)
            {
                BC.ActivateInstantBark(GiveRandomBark(victory_barks));
            }
        }
    }
}
