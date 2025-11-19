using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject rightSide;
    public GameObject leftSide;

    public GameObject startButton;
    public GameObject playerWheelHolder;
    public GameObject enemyWheelHolder;
    public GameObject StoryEventHolder;
    public GameObject Guilliotine;
    public GameObject MC;

    public GameObject player;

    public bool choise_panel_active = true;

    public List<GameObject> sparks;

    public bool round_started = false;

    public void FirstTurn()
    {
        if(round_started)
        {
            round_started = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().ActivateFirstTurnEffects();
            GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().ActivateFirstTurnEffects();
            RLController RLC = GameObject.Find("EventSystem").GetComponent<RLController>();
            for(int i = 0; i < RLC.chosen_buffs.Count; i++)
            {
                if(RLC.chosen_buffs[i].GetComponent<Slow>())
                {
                    RLC.chosen_buffs[i].GetComponent<Slow>().ApplyBuff();
                }
            }
        }
    }

    public void ChangeGear()
    {
        player.GetComponent<PlayerContoller>().ChangeWheel();
    }

    public void CheckAnimation()
    {
        AnimatorStateInfo stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("MachineClose"))
        {
            GetComponent<Test>().reverse = false;
        }
        else if (stateInfo.IsName("MachineOpen"))
        {
            GetComponent<Test>().reverse = true;
        }
    }

    public void AnimationStart()
    {
        InvokeBossGearChange();
        rightSide.transform.GetChild(3).GetComponent<EnemyController>().HandleEnemy();
        ToggleIdle();
        EndTheGame(); //Currently the only way to lose
    }

    public void ToggleInBattle()
    {
        if(!MC.GetComponent<MainController>().CompareState(MainController.State.in_battle))
        {
            MC.GetComponent<MainController>().SetNewState(MainController.State.in_battle);
        } else
        {
            MC.GetComponent<MainController>().SetNewState(MainController.State.transition);
        }
    }

    public void ToggleIdle()
    {
        if(!MC.GetComponent<MainController>().CompareState(MainController.State.idle))
        {
            MC.GetComponent<MainController>().SetNewState(MainController.State.idle);
        } else
        {
            MC.GetComponent<MainController>().SetNewState(MainController.State.transition);
        }
    }

    public void EndTheGame()
    {
        if(MC.GetComponent<MainController>().game_state == MainController.State.dead)
        {
            Guilliotine.GetComponent<Test>().PlayAnimation("Lose");
        }
    }

    //Look some time if there is better way
    public void ActivateParticle(int index)
    {
        if(index == 2) transform.GetChild(0).GetChild(4).GetComponent<Test>().PlayAnimation("Reveal bulbs");
        sparks[index].GetComponent<ParticleSystem>().Play();
    }

    bool smoke3 = true;
    public void ActivateSmoke3()
    {
        if(smoke3) sparks[4].GetComponent<ParticleSystem>().Play();
        smoke3 = !smoke3;
    }

    public void InvokeBossGearChange()
    {
        if (StoryEventHolder.transform.GetChild(0).GetComponent<BossBattle>())
        {
            StoryEventHolder.transform.GetChild(0).GetComponent<BossBattle>().UpdateGear();
        } else if(enemyWheelHolder.transform.GetChild(0).name != "Enemy Wheel")
        {
            GameObject active_gear = enemyWheelHolder.transform.GetChild(0).gameObject;
            enemyWheelHolder.transform.GetChild(1).SetAsFirstSibling();
            enemyWheelHolder.transform.GetChild(0).gameObject.SetActive(true);

            switch (active_gear.name)
            {
                case "Wheel 4": active_gear.transform.SetSiblingIndex(1); break;
                case "Wheel 5": active_gear.transform.SetSiblingIndex(2); break;
                case "Wheel 6": active_gear.transform.SetSiblingIndex(3); break;
            }
            active_gear.SetActive(false);
        }
    }
}
