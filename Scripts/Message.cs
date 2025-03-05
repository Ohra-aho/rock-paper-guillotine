using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] Animation animation;
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
        man.GetComponent<AudioSource>().clip = clip;
        man.GetComponent<AudioSource>().Play();
        activated = true;
    }
}
