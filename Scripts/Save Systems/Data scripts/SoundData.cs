using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    public float music;
    public float sound_effects;
    public float ambience;
    public float man;

    public bool mute_music;
    public bool mute_sound_effects;
    public bool mute_ambience;
    public bool mute_man;

    public SoundData(List<SoundTarget> sound_targets)
    {
        for(int i = 0; i < sound_targets.Count; i++)
        {
            switch (sound_targets[i].name)
            {
                case "Music":
                    music = sound_targets[i].volume;
                    mute_music = sound_targets[i].mute;
                    break;
                case "Ambience":
                    ambience = sound_targets[i].volume;
                    mute_music = sound_targets[i].mute;
                    break;
                case "Sound Effect":
                    sound_effects = sound_targets[i].volume;
                    mute_sound_effects = sound_targets[i].mute;
                    break;
                case "Man":
                    man = sound_targets[i].volume;
                    mute_man = sound_targets[i].mute;
                    break;
            }
        }
    }
}
