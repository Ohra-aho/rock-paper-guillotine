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

    public void AnimationStart()
    {
        rightSide.transform.GetChild(2).GetComponent<EnemyController>().HandleEnemy();
        ActivateStartButton();
        startButton.GetComponent<StartButton>().sidesOutOfView = true;
        playerWheelHolder.GetComponent<Button>().interactable = true;
    }

    public void AnimationEnd()
    {
        startButton.GetComponent<StartButton>().sidesOutOfView = false;
    }

    public void ActivateStartButton()
    {
        startButton.GetComponent<Button>().interactable = true;
    }

    public void DeactivateStartButton()
    {
        startButton.GetComponent<Button>().interactable = false;
        playerWheelHolder.GetComponent<Button>().interactable = false;
    }
}
