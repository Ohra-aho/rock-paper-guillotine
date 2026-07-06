using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessengerScript : MonoBehaviour
{
	public List<Message> possible_messages;
	public Message tutorial;

	public UnityEvent tutorial_requirement;	

	bool tutorial_needed = false;

	public List<ManAnimator.Frame> frames;

    MainController MC;

    bool executioner = false;

    string[][] messages = { };

    string[] executioner_message = { };

	StoryCheckList SCL;
	StoryController SC;
	GameObject main_controller;

	void Awake()
	{
		main_controller = GameObject.Find("EventSystem");
		SCL = main_controller.GetComponent<StoryCheckList>();
        SC = main_controller.GetComponent<StoryController>();

		if(tutorial_requirement != null) tutorial_requirement.Invoke();
		if(tutorial_needed)
		{
			Instantiate(tutorial, transform.parent);
		} else
		{
			if(possible_messages.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, possible_messages.Count);
				Instantiate(possible_messages[index], transform.parent);
			}
		}
		GetComponent<StoryEvent>().over = true;
	}

	public void Greetings()
	{
		MainController MC = main_controller.GetComponent<MainController>();
        messages = MC.GetComponent<StoryController>().GiveMessages();
        executioner_message = MC.GetComponent<StoryController>().GiveExecutionerMessage();
        executioner = MC.GetComponent<StoryController>().executioner;

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        int index = MC.GetComponent<StoryCheckList>().greeting_index;
        List<string> temp = new List<string>();
        MC.GetComponent<StoryCheckList>().greeting_index = index + 1;
        
        if(executioner)
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(guillotine); Make this work later
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
            possible_messages[0].GetComponent<Message>().lines = temp;
            possible_messages[0].GetComponent<Message>().sprite_frames = ExtractFrameSprites(index);
		}
	}

    private List<int> ExtractFrameSprites(int index)
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < messages[index].Length; i++)
        {
            try
            {
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

	public void Achievement()
	{
		if (!SCL.first_achievement && main_controller.GetComponent<RLController>().achievements.Count > 0)
		{
			SCL.first_achievement = true;
			tutorial_needed = true;
		} else
		{
			tutorial_needed = false;
		}
	}

	public void AchievementPick()
	{
		if (!SCL.first_achievement_pick && main_controller.GetComponent<RLController>().picks > 0)
		{
			SCL.first_achievement_pick = true;
			tutorial_needed = true;
		} else
		{
			tutorial_needed = false;
		}
	}

	public void FirstBoss()
	{
		if(!SCL.first_boss_met)
		{
			tutorial_needed = true;
		} else
		{
			tutorial_needed = false;
		}
	}

	public void FirstBossVictory()
	{
		if(!SCL.first_boss_beaten)
		{
			tutorial_needed = true;
		} else
		{
			tutorial_needed = false;
		}
	}
}
