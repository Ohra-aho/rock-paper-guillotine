using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryData
{
    public int playthroughs;
    public int encounter_index;
	public string[] achievements;
	public int picks;
	public string[] ascended_1;
	public int[] ascended_2;
    public StoryData(StoryController story_controller, RLController rl_controller)
    {
        playthroughs = story_controller.playthroughts;
        encounter_index = story_controller.storyIndex;
		//Achievement data
		achievements = rl_controller.achievements.ToArray();
		picks = rl_controller.picks;
		List<string> names = new List<string>(rl_controller.ascended_weapons.Keys);
		List<int> tiers = new List<int>(rl_controller.ascended_weapons.Values);
		ascended_1 = names.ToArray();
		ascended_2 = tiers.ToArray();
    }
}
