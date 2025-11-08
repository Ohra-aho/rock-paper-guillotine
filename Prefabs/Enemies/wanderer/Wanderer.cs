using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    bool bag_broken = false;
    public bool stick_missed = false;

    public GameObject first_victory;

    private void Awake()
    {
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeAChoise;
        if(!GameObject.Find("EventSystem").GetComponent<StoryCheckList>().first_victory)
        {
            GameObject.Find("EventSystem").GetComponent<MainController>().victory_message = first_victory;
        }
    }

    public int MakeAChoise(MainController.Choise c)
    {
        if(!bag_broken)
        {
            bag_broken = true;
            return 0;
        } else if(!stick_missed)
        {
            return 2;
        } else
        {
            stick_missed = false;
            return 1;
        }
    }
}
