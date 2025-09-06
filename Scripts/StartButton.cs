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

    public GameObject story_event_holder;

    public bool isActive;

    public bool deactivated; //If start button needs to be deactivated individually

    MainController MC;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    private void Update()
    {
        FindEncounter();
    }

    public void FindEncounter()
    {
        if(MC.CompareState(MainController.State.idle))
        {
            bool found = false;
            for (int i = 0; i < story_event_holder.transform.childCount; i++)
            {
                if (!story_event_holder.transform.GetChild(i).GetComponent<Encounter>())
                {
                    found = false;
                }
                else
                {
                    found = true;
                    break;
                }
            }
            GetComponent<NonUIButton>().interactable = found;

        } else if(MC.CompareState(MainController.State.in_battle))
        {
            GetComponent<NonUIButton>().interactable = true;
        } else
        {
            GetComponent<NonUIButton>().interactable = false;
        }

    }

    public void Activate()
    {
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().defeat = false;
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().victory = false;
        GetComponent<SpriteRenderer>().sprite = active;
        machine.GetComponent<Test>().PlayAnimation("CloseMachine");
        isActive = true;
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarUp();
        machine.GetComponent<Machine>().round_started = true;
    }

    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarDown();
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.PowerHealthBarDown();
        GameObject.Find("EventSystem").GetComponent<MainController>().GiveUp();
        isActive = false;
    }

    public void EndRound()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarDown();
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.PowerHealthBarDown();
        GameObject.Find("PlayerWheelHolder").GetComponent<NonUIButton>().individual_interactable = true;
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
        bool dead = player.transform.GetChild(2).GetComponent<HealthBar>().CheckIfDead();
        if (dead)
        {
            MC.SetNewState(MainController.State.dead);
        } else
        {
            Activate();
        }
    }

    private int LastIndex()
    {
        int index = transform.childCount - 1;
        if (index < 0) index = 0;
        return index;
    }

    public void PlayAudio()
    {
        if (isActive) transform.GetChild(LastIndex()).GetChild(1).GetComponent<AudioPlayer>().PlayClip();
        else transform.GetChild(LastIndex()).GetChild(0).GetComponent<AudioPlayer>().PlayClip();
    }



}
