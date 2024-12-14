using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Sprite active;
    [SerializeField] Sprite inactive;

    public GameObject machine;
    public GameObject player;

    public bool isActive;

    public bool sidesOutOfView = true;

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = active;
        machine.GetComponent<Test>().PlayAnimation("CloseMachine");
        isActive = true;
    }

    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        GameObject.Find("EventSystem").GetComponent<MainController>().GiveUp();
        isActive = false;
    }

    public void EndRound()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        isActive = false;
    }

    public void press() 
    { 
        if(!isActive)
        {
            CheckPlayerStatus();
        } else
        {
            Deactivate();
        }
    }

    public void CheckPlayerStatus()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        bool dead = player.transform.GetChild(2).GetComponent<HealthBar>().checkIfDead();
        if (dead)
        {
            MC.dead = true;
        } else
        {
            Activate();
        }
    }

    

}
