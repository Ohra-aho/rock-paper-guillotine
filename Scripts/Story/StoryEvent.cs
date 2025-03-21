using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryEvent : MonoBehaviour
{
    /*[HideInInspector]*/ public bool over = false;
    public UnityEvent eventFunction;

    private void Update()
    {
        if(over)
        {
            //GameObject.Find("EventSystem").GetComponent<StoryController>().events.RemoveAt(0);
            Destroy(this.gameObject);
        }
    }

    public void Procceed()
    {
        eventFunction.Invoke();
    }
}
