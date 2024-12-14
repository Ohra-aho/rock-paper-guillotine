using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryEvent : MonoBehaviour
{
    [HideInInspector] public bool over = false;
    public UnityEvent eventFunction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Procceed()
    {
        eventFunction.Invoke();
    }
}
