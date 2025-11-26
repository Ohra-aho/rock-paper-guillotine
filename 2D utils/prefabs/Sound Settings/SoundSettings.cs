using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    //Place to games EventSystem or similar gameobject

    public List<SoundTarget> soundTargets = new List<SoundTarget>();
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        SoundData data = SaveSystem.LoadSoundSettings();
        if(data != null)
        {
            LoadSoundSettings(data);
        } else
        {
            soundTargets.Add(new SoundTarget("Music", false, 1));
            soundTargets.Add(new SoundTarget("Ambience", false, 1));
            soundTargets.Add(new SoundTarget("Sound Effect", false, 0.2f));
            soundTargets.Add(new SoundTarget("Man", false, 1));
        }
    }

    //Changes values of sound targets
    public void ChangeValues(string type, bool mute, float volume)
    {
        for(int i = 0; i < soundTargets.Count; i++)
        {
            if(soundTargets[i].name == type)
            {
                soundTargets[i].volume = volume;
                soundTargets[i].mute = mute;
            }
        }
    }

    public void SaveSoundSettings()
    {
        SaveSystem.SaveSoundSettings(new SoundData(soundTargets));
    }

    public void LoadSoundSettings(SoundData data)
    {
        soundTargets.Add(new SoundTarget("Music", data.mute_music, data.music));
        soundTargets.Add(new SoundTarget("Ambience", data.mute_ambience, data.ambience));
        soundTargets.Add(new SoundTarget("Sound Effect", data.mute_sound_effects, data.sound_effects));
        soundTargets.Add(new SoundTarget("Man", data.mute_man, data.man));
    }
}

public class SoundTarget
{
    public string name;
    public bool mute;
    public float volume;

    public SoundTarget(string name, bool mute, float volume)
    {
        this.name = name;
        this.mute = mute;
        this.volume = volume;
    }
}
