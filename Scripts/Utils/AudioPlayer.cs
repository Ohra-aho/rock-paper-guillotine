using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip clip;
    public bool loop = false;
    public bool ongoing = false;
    public bool mute = false;
    [HideInInspector] public float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Add audio source
        gameObject.AddComponent<AudioSource>();
        //Set parameters
        GetComponent<AudioSource>().clip = clip;
        if (loop) GetComponent<AudioSource>().loop = true;
        if (ongoing) GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        //if(GetComponent<AudioSource>().volume != volume) 
        //    GetComponent<AudioSource>().volume = volume;
        if(mute) GetComponent<AudioSource>().mute = true;
    }

    public void PlayClip()
    {
        GetComponent<AudioSource>().Play();
    }

    public void PauseClip()
    {
        GetComponent<AudioSource>().Pause();
    }

    public void StopClip()
    {
        GetComponent<AudioSource>().Stop();
    }


}
