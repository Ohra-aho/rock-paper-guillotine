using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject rightSide;
    public GameObject leftSide;

    public GameObject startButton;
    public GameObject playerWheelHolder;
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
        sparks[index].GetComponent<ParticleSystem>().Play();
    }

    bool smoke3 = true;
    public void ActivateSmoke3()
    {
        if(smoke3) sparks[4].GetComponent<ParticleSystem>().Play();
        smoke3 = !smoke3;
    }
}
