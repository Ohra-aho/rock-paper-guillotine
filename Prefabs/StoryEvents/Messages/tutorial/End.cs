using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private string[][] end_messages =
    {
        new string[] {"Something over here.", "I will figure this out later."}, ////////Placeholders
        new string[] {"This is a placeholder", "I will figure this out later."},
        new string[] {"Nothing to see here", "This is a placeholder"},
    };
    public void Inisiate()
    {
        GameObject event_system = GameObject.Find("EventSystem");
        int ends = event_system.GetComponent<StoryCheckList>().end_counter;
        ends++;
        if(ends > 0 && !event_system.GetComponent<StoryController>().executioner)
        {
            int x = Random.Range(0, end_messages.Length);
            GetComponent<Message>().lines.Clear();
            GetComponent<Message>().sprite_frames.Clear();
            for (int i = 0; i < end_messages[x].Length; i++)
            {
                GetComponent<Message>().lines.Add(end_messages[x][i]);
                GetComponent<Message>().sprite_frames.Add(0);
            }
        } else if(event_system.GetComponent<StoryController>().executioner)
        {
            GetComponent<Message>().executioner = true;
            GetComponent<Message>().lines.Clear();
            GetComponent<Message>().sprite_frames.Clear();
            if (ends == 0)
            {
                GetComponent<Message>().lines.Add("Well I beat it at least.");
                GetComponent<Message>().lines.Add("I can go now.");
                GetComponent<Message>().sprite_frames.Add(0);
                GetComponent<Message>().sprite_frames.Add(0);
            }
            else
            {
                GetComponent<Message>().lines.Add("It's over.");
                GetComponent<Message>().lines.Add("It truly is.");
                GetComponent<Message>().sprite_frames.Add(0);
                GetComponent<Message>().sprite_frames.Add(0);
            }
        }
        event_system.GetComponent<StoryCheckList>().end_counter++;

    }
}
