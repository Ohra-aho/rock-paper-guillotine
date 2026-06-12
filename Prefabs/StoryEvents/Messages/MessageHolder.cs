using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public GameObject guillotine;

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
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(guillotine);
            for (int i = 0; i < executioner_message.Length; i++)
            {
                temp.Add(executioner_message[i]);
            }
        } else
        {
            for (int i = 0; i < messages[index].Length; i++)
            {
                if(messages[index][i].Contains("[kill]"))
                {
                    MC.game_state = MainController.State.dead;
					GameObject.Find("man").GetComponent<SpriteRenderer>().sprite = GameObject.Find("man").GetComponent<ManAnimator>().man_sheet[20];
                    GameObject.Find("Machine").GetComponent<Machine>().EndTheGame();
                    break;
                } else
                {
                    try
                    {
                        string line = messages[index][i];
                        int test = Int32.Parse(line[line.Length-1].ToString());
						string number = GetNumber(line);
                        temp.Add(line.Substring(0, line.Length-number.Length));
                    } catch
                    {
                        temp.Add(messages[index][i]);
                    }
                }
            }
        }
        if(temp.Count > 0)
        {
            new_message.GetComponent<Message>().lines = temp;
            new_message.GetComponent<Message>().sprite_frames = ExtractFrameSprites(index);
            if (executioner) new_message.GetComponent<Message>().executioner = true;
            new_message.GetComponent<Message>().Inisiate();
        } else
        {
            Destroy(new_message);
        }
        GetComponent<StoryEvent>().over = true;
    }

    private List<int> ExtractFrameSprites(int index)
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < messages[index].Length; i++)
        {
            try
            {
                //int frame = Int32.Parse(messages[index][i][messages[index][i].Length - 1].ToString());
				string proto_frame = GetNumber(messages[index][i]);
				int frame = Int32.Parse(proto_frame);
                temp.Add(frame);
            } catch
            {
                temp.Add(6);
            }
        }
        return temp;
    }

	private string GetNumber(string message)
	{
		string whole = "";
		string reverse_whole = "";
		for(int i = message.Length-1; i >= 0; i--)
		{
			try
			{
				int temp = Int32.Parse(message[i].ToString());
				whole += message[i];
			} catch
			{
				break;
			}
		}
		for(int i = whole.Length-1; i >= 0; i--)
		{
			reverse_whole += whole[i];
		}
		return reverse_whole;
	}
}
