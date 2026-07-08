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
		messages = main_controller.GetComponent<StoryController>().GiveMessages();
		executioner_message = main_controller.GetComponent<StoryController>().GiveExecutionerMessage();
		int index = main_controller.GetComponent<StoryCheckList>().greeting_index;
		possible_messages[0].lines.Clear();
		if(main_controller.GetComponent<StoryController>().executioner)
		{
			possible_messages[0].lines.AddRange(executioner_message);
		} else
		{
			possible_messages[0].lines.AddRange(messages[index]);
			main_controller.GetComponent<StoryCheckList>().greeting_index++;
		}
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

	public void FavouriteWeapon()
	{
		GameObject weapon = GameObject.Find("Favourite weapon 2");
		if(weapon != null) 
		{
			Weapon w = weapon.GetComponent<FavouriteWeaponScript>().weapon;
			if(w != null)
			{
				if(w.favourite != "")
				{
					tutorial.lines.Clear();
					tutorial.lines.Add(w.favourite);
					tutorial_needed = true;
				} 
				else tutorial_needed = false;

				for(int i = possible_messages.Count-1; i >= 3; i--)
				{
					possible_messages.RemoveAt(i);
				}
			} else
			{
				for(int i = 0; i < 3; i++)
				{
					possible_messages.RemoveAt(0);
				}
			}
		}
	}
}
