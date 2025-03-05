using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public bool continious = false;
    public UnityEvent trigger;

    public bool reverse = false;

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

    //Structure should be something like this:
    /*
     audioPlayer
        |__ clip_1
            clip_2
            clip_3
     */

    private int LastIndex()
    {
        int index = transform.childCount - 1;
        if (index < 0) index = 0;
        return index;
    }

    public void PlayAudio(int clip)
    {
        if(!reverse) transform.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().PlayClip();    
    }

    public void PlayAudioIfReverse(int clip)
    {
        if(reverse)
        {
            transform.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().PlayClip();
        }
    }

    //Might need some sort of fade out of something
    public void StopAudio(int clip)
    {
        transform.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().StopClip();
    }

    public void LastLoop(int clip)
    {
        transform.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().StopLoop();
    }
}
