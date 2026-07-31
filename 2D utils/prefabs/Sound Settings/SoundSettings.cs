using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    //Place to games EventSystem or similar gameobject

    public List<SoundTarget> soundTargets = new List<SoundTarget>();
    public bool pause = false;
	public float brightness = 0.1f;

	public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        SoundData data = SaveSystem.LoadSoundSettings();
		light = GameObject.Find("Global Light 2D");
        if(data != null)
        {
            LoadSoundSettings(data);
        } else
        {
			soundTargets.Add(new SoundTarget("Master volume", false, 0.7f));
            soundTargets.Add(new SoundTarget("Music", false, 1));
            soundTargets.Add(new SoundTarget("Sound effects", false, 0.2f));
        }
    }

	private void Update()
	{
		light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = brightness / 10f;
	}

    //Changes values of sound targets
    public void ChangeValues(string type, bool mute, float volume)
    {
        /*for(int i = 0; i < soundTargets.Count; i++)
        {
            if(soundTargets[i].name == type)
            {
                soundTargets[i].volume = volume;
                soundTargets[i].mute = mute;
            }
        }*/
    }

    public void SaveSoundSettings()
    {
        SaveSystem.SaveSoundSettings(new SoundData(soundTargets, brightness));
    }

    public void LoadSoundSettings(SoundData data)
    {
		for(int i = 0; i < data.targets.Length; i++)
		{
        	soundTargets.Add(new SoundTarget(data.targets[i].name, data.targets[i].mute, data.targets[i].volume));
		}
		brightness = data.brightness;
    }
}
[Serializable]
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
