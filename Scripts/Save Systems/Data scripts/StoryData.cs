using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryData
{
    public int playthroughs;
    public int encounter_index;
	//Achievements
	public string[] achievements;
	public int picks;
	public string[] ascended_1;
	public int[] ascended_2;
	//Checklist
	public bool first_forfeit;
	public bool first_victory;
	public bool first_boss_met;
	public bool first_boss_beaten;
	public bool first_achievement;
	public bool first_achievement_pick;
	public bool executioner_dead;
	public int greeting_index;
	public int end_counter;
    public StoryData(StoryController story_controller, RLController rl_controller, StoryCheckList check_list)
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
		//Story Checklist
		first_forfeit = check_list.first_forfeit;
		first_victory = check_list.first_victory;
		first_boss_met = check_list.first_boss_met;
        first_boss_beaten = check_list.first_boss_beaten;
        first_achievement = check_list.first_achievement;
        first_achievement_pick = check_list.first_achievement_pick;
        greeting_index = check_list.greeting_index;
        executioner_dead = check_list.executioner_dead;
        end_counter = check_list.end_counter;
    }
}
