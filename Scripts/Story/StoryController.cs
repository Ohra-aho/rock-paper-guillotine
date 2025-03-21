using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;

    //public GameObject story;

    int storyIndex = -1;

    public void InvokeNextEvent()
    {
        if(story_event_holder.transform.childCount == 0 && storyIndex < events.Count-1)
        {
            storyIndex++;
            GameObject new_event = Instantiate(events[storyIndex], story_event_holder.transform);
        } 
    }
}
