using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryData
{
    public int playthroughs;

    public StoryData(StoryController stroy_controller)
    {
        playthroughs = stroy_controller.playthroughts;
    }
}
