using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public bool continious = false;
    public UnityEvent trigger;

    private void Start()
    {
        if (continious) GetComponent<Animator>().speed = 0;
    }

    public void InvokeTrigger()
    {
        trigger.Invoke();
    }

    public void PlayAnimation(string trigger)
    {
        GetComponent<Animator>().SetTrigger(trigger);
    }

    public void PlayBoolAnimation(string name, bool trigger)
    {
        GetComponent<Animator>().SetBool(name, trigger);
    }

    public void PauseAnimation()
    {
        GetComponent<Animator>().speed = 0;
    }

    public void UnPauseAnimation()
    {
        GetComponent<Animator>().speed = 1;
    }

    public bool Paused()
    {
        return GetComponent<Animator>().speed == 0;
    }
}
