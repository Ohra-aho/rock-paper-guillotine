using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    public GameObject rightSide;
    public GameObject leftSide;

    public GameObject startButton;
    public GameObject playerWheelHolder;

    private void Update()
    {
        //CheckAnimation();
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
        rightSide.transform.GetChild(2).GetComponent<EnemyController>().HandleEnemy();
        ActivateStartButton();
        startButton.GetComponent<StartButton>().sidesOutOfView = true;
        playerWheelHolder.GetComponent<NonUIButton>().interactable = true;
    }

    public void AnimationEnd()
    {
        startButton.GetComponent<StartButton>().sidesOutOfView = false;
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
