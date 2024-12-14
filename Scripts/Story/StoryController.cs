using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;

    public void InvokeNextEvent()
    {
        for(int i = 0; i < events.Count; i++)
        {
            if(!events[i].GetComponent<StoryEvent>().over)
            {
                events[i].GetComponent<StoryEvent>().Procceed();
                break;
            }
        }
    }
}
