using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHolder : MonoBehaviour
{
    //public  List<GameObject> messages;
    public GameObject message;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;

    MainController MC;

    bool executioner = false;

    string[][] messages = { };

    string[] executioner_message = { };

    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        messages = MC.GetComponent<StoryController>().GiveMessages();
        executioner_message = MC.GetComponent<StoryController>().GiveExecutionerMessage();
        executioner = MC.GetComponent<StoryController>().executioner;

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        int index = MC.GetComponent<StoryCheckList>().greeting_index;
        GameObject new_message = Instantiate(message, transform.parent);
        List<string> temp = new List<string>();
        MC.GetComponent<StoryCheckList>().greeting_index = index + 1;

        //Add new starting weapons
        List<GameObject> starting_weapons = MC.GetComponent<StartingWeapons>().GiveStartingWeapons();
        if(starting_weapons.Count > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().ClearInventory();
            for (int i = 0; i < starting_weapons.Count; i++)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(starting_weapons[i]);
            }
        }
        
        if(executioner)
        {
            for (int i = 0; i < executioner_message.Length; i++)
            {
                temp.Add(executioner_message[i]);
            }
        } else
        {
            for (int i = 0; i < messages[index].Length; i++)
            {
                if(messages[index][i] == "[kill]")
                {
                    MC.game_state = MainController.State.dead;
                    GameObject.Find("Machine").GetComponent<Machine>().EndTheGame();
                    break;
                } else
                {
                    temp.Add(messages[index][i]);
                }
            }
        }
        if(temp.Count > 0)
        {
            new_message.GetComponent<Message>().lines = temp;
            new_message.GetComponent<Message>().Inisiate();
        } else
        {
            Destroy(new_message);
        }
        GetComponent<StoryEvent>().over = true;

    }
}
