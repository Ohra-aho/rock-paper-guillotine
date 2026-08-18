using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exeption : MonoBehaviour
{
	public List<string> new_lines;
	public List<int> new_sprites;

	public GameObject bark;
	public GameObject bark_2;
	private void Awake()
	{
		if(bark != null)
		{
			StoryCheckList SCL = GameObject.Find("EventSystem").GetComponent<StoryCheckList>();
			if(!SCL.first_victory && SCL.GetComponent<StoryController>().playthroughts > 0)
			{
				GameObject new_bark = Instantiate(bark_2, GameObject.Find("BarkHolder").transform);
				new_bark.GetComponent<Bark>().Inisiate();
				GetComponent<StoryEvent>().over = true;	
				SCL.GetComponent<StoryController>().playthroughts = 0;
			} else
			{
				GameObject new_bark = Instantiate(bark, GameObject.Find("BarkHolder").transform);
				new_bark.GetComponent<Bark>().Inisiate();
				GetComponent<StoryEvent>().over = true;	
			}
		}
	}

	public void PlayMessage()
	{
		StoryCheckList SCL = GameObject.Find("EventSystem").GetComponent<StoryCheckList>();
		if(!SCL.first_victory && SCL.GetComponent<StoryController>().playthroughts > 0)
		{
			if(new_lines.Count > 0)
			{
				GetComponent<Message>().lines = new_lines;
				GetComponent<Message>().sprite_frames = new_sprites;
				GetComponent<Message>().PlayMessage();	
			} else
			{
				GetComponent<StoryEvent>().over = true;
			}
		} else
		{

			GetComponent<Message>().PlayMessage();
		}
	}
}
