using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;

    //ERROR//
    //Needs to instanciate the event. Could make event management even easier..
    public void InvokeNextEvent()
    {
        if(story_event_holder.transform.childCount == 0 && events.Count > 0)
        {
            GameObject new_event = Instantiate(events[0], story_event_holder.transform);
        } 
    }
}
