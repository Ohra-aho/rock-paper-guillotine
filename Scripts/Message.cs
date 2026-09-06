using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public List<string> lines;
    public List<int> sprite_frames;

    GameObject man;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;
    ManAnimator MA;
    MainController MC;

	MainController.State prev_state;

    //public bool executioner = false;
    private void Update()
    {
        //if(MC == null) MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		GetComponent<StoryEvent>().eventFunction.Invoke();
		prev_state = MC.game_state;
		MC.game_state = MainController.State.dialog;
    }

    public void Inisiate()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        if (!MC.GetComponent<StoryController>().executioner)
        {
            if (GameObject.Find("man") != null) HandleMessage();
            else GetComponent<StoryEvent>().over = true;
        }
        else if(MC.GetComponent<StoryController>().executioner)
        {
            if (GameObject.Find("man") != null) HandleMessage();
            else GetComponent<StoryEvent>().over = true;
        }
        else
        {
			MC.game_state = prev_state;
            GetComponent<StoryEvent>().over = true;
        }
    }


	public void CreateMessage(List<string> messages)
	{
        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        List<string> temp = new List<string>();
        
		for (int i = 0; i < messages.Count; i++)
		{
			try
			{
				string line = messages[i];
				int test = Int32.Parse(line[line.Length-1].ToString());
				string number = GetNumber(line);
				temp.Add(line.Substring(0, line.Length-number.Length));
			} catch
			{
				temp.Add(messages[i]);
			}
		}
        
        if(temp.Count > 0)
        {
            lines = temp;
            sprite_frames = ExtractFrameSprites(messages);
		}
	}

    private List<int> ExtractFrameSprites(List<string> messages)
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < messages.Count; i++)
        {
            try
            {
				string proto_frame = GetNumber(messages[i]);
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


    private void HandleMessage()
    {
		if(sprite_frames.Count == 0 && lines.Count > 0)
		{
			CreateMessage(lines);
		}
		
        MA = GameObject.Find("man").GetComponent<ManAnimator>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        string[] dialog = lines.ToArray();

        for (int i = 0; i < sprite_frames.Count; i++)
        {
            string line = dialog[i];

            frames.Add(
                new ManAnimator.Frame(
                    MA.man_sheet[sprite_frames[i]],
                    null,
                    line
                )
            );
        }
    }

    private void OnDestroy()
    {
		GameObject event_system = GameObject.Find("EventSystem");
		if(event_system != null)
		{
			MainController MC = event_system.GetComponent<MainController>();
			if(MC != null)
			{
				if(GameObject.FindGameObjectWithTag("Rewards") != null) MC.game_state = MainController.State.reward;
				else if(GameObject.FindGameObjectWithTag("Inventory") != null) MC.game_state = MainController.State.re_arming;
				else MC.SetNewState(MainController.State.idle);
			}	
		}
    }

    public void DisableButtons()
    {
        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        MC.SetNewState(MainController.State.dialog);
    }

    public void PlayMessage()
    {
		if (GetComponent<End>())
        {
            GetComponent<End>().Inisiate();
        }
        if(lines.Count > 0)
        {
            Inisiate();
        }  

        man = GameObject.Find("man");
        if(man != null) man.GetComponent<ManAnimator>().ManMessage(frames);
        activated = true;
    }

	
}
