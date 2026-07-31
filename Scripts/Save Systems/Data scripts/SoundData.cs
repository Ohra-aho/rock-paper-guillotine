using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
	public SoundTarget[] targets;
	public float brightness;
    

    public SoundData(List<SoundTarget> sound_targets, float brightness)
    {
        targets = sound_targets.ToArray();
		this.brightness = brightness;
    }
}
