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
        EndTheGame(); //Currently the only way to lose
    }

    public void ToggleInBattle()
    {
        EnemyController EC = GameObject.Find("EnemyHolder").GetComponent<EnemyController>();
        EC.in_battle = !EC.in_battle;
    }

    public void EndTheGame()
    {
        if(MC.GetComponent<MainController>().dead)
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
