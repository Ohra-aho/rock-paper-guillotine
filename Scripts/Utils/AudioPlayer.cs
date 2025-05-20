using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public string type;
    public AudioClip clip;
    public bool loop = false;
    public bool ongoing = false;
    public bool mute = false;
    public float volume = 1f;
    public float volume_modifier = 1f;
    public float pitch = 1;
    public float stereo_pan;

    SoundSettings settings;
    
    // Start is called before the first frame update
    void Start()
    {
        //Add audio source
        gameObject.AddComponent<AudioSource>();
        settings = GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundSettings>();
        //Set parameters
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().pitch = pitch;
        GetComponent<AudioSource>().panStereo = stereo_pan;
        if (loop) GetComponent<AudioSource>().loop = true;
        if (ongoing) GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        //if(GetComponent<AudioSource>().volume != volume) 
        if (settings.pause) GetComponent<AudioSource>().Pause();
        else if (!settings.pause && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().UnPause();

        Upkeep();


    }

    public void Upkeep()
    {
        //Get sound targets from settings and adapt to them
        List<SoundTarget> soundTargets = settings.soundTargets;
        for (int i = 0; i < soundTargets.Count; i++)
        {
            if (soundTargets[i].name == type)
            {
                mute = soundTargets[i].mute;
                volume = soundTargets[i].volume;
            }
        }
        if (GetComponent<AudioSource>().mute != mute) GetComponent<AudioSource>().mute = mute;
        if (GetComponent<AudioSource>().volume != volume) GetComponent<AudioSource>().volume = volume * volume_modifier;
    }

    public void StopLoop()
    {
        GetComponent<AudioSource>().loop = false;
    }

    public void PlayClip()
    {
        GetComponent<AudioSource>().loop = loop; 
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
