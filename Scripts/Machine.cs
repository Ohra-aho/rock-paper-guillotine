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

    public GameObject player;

    public bool choise_panel_active = false;

    private void Update()
    {
        //CheckAnimation();
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
        ActivateStartButton();
        startButton.GetComponent<StartButton>().sidesOutOfView = true;
        playerWheelHolder.GetComponent<NonUIButton>().interactable = true;
    }

    public void AnimationEnd()
    {
        startButton.GetComponent<StartButton>().sidesOutOfView = false;
        choise_panel_active = !choise_panel_active;
    }

    public void ActivateStartButton()
    {
        startButton.GetComponent<NonUIButton>().interactable = true;
    }

    public void DeactivateStartButton()
    {
        startButton.GetComponent<NonUIButton>().interactable = false;
        playerWheelHolder.GetComponent<NonUIButton>().interactable = false;
    }
}
