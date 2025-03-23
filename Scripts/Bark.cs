using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public int bark_index;
    public string trigger;
    private void Awake()
    {
        GameObject.Find("man").GetComponent<Barker>().SetUpTriggerBark(bark_index, trigger);
        GetComponent<StoryEvent>().over = true;
    }
}
