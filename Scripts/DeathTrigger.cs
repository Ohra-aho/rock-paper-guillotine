using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("EventSystem").GetComponent<MainController>().GiveUp();
        GetComponent<StoryEvent>().over = true;
    }
}
