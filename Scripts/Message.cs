using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public int id;
    GameObject man;
    private bool activated = false;

    private void Awake()
    {
        GetComponent<StoryEvent>().Procceed();   
    }

    private void Update()
    {
        if(man != null && activated)
        {
            if(!man.GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<StoryEvent>().over = true;
            }
        }
    }

    public void PlayMessage()
    {
        man = GameObject.Find("man");
        man.GetComponent<ManAnimator>().ManMessage(id);
        activated = true;
    }
}
