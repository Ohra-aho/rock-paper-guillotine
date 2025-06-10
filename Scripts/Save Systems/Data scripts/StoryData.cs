using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryData
{
    public int playthroughs;
    public int encounter_index;
    public int narrative_index;

    public StoryData(StoryController story_controller)
    {
        playthroughs = story_controller.playthroughts;
        encounter_index = story_controller.storyIndex;
        narrative_index = story_controller.narrative_index;
    }
}
