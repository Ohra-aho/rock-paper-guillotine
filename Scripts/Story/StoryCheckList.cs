using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCheckList : MonoBehaviour
{
    //Tutorial
    public bool first_forfeit = false;
    public bool first_victory = false;

    public bool first_boss_met = false;
    public bool first_boss_beaten = false;

    public bool first_achievement = false;
    public bool first_achievement_pick = false;

    public void SaveStoryCheckList()
    {
        CheckList data = new CheckList
            (
                first_forfeit,
                first_victory,

                first_boss_met,
                first_boss_beaten,

                first_achievement,
                first_achievement_pick
            );
        SaveSystem.SaveStoryChecklist(data);
    }

    public void LoadStoryCheckList()
    {
        CheckList data = SaveSystem.LoadStoryChecklist();
        if(data != null)
        {
            first_forfeit = data.first_forfeit;
            first_victory = data.first_victory;
            
            first_boss_met = data.first_boss_met;
            first_boss_beaten = data.first_boss_beaten;

            first_achievement = data.first_achievement;
            first_achievement_pick = data.first_achievement_pick;
        }
    }

    [System.Serializable]
    public class CheckList
    {
        public bool first_forfeit;
        public bool first_victory;

        public bool first_boss_met;
        public bool first_boss_beaten;

        public bool first_achievement;
        public bool first_achievement_pick;

        public CheckList
            (
                bool first_forfeit,
                bool first_victory,

                bool first_boss_met,
                bool first_boss_beaten,

                bool first_achievement,
                bool first_achievement_pick
            )
        {
            this.first_forfeit = first_forfeit;
            this.first_victory = first_victory;
            this.first_boss_met = first_boss_met;
            this.first_boss_beaten = first_boss_beaten;
            this.first_achievement = first_achievement;
            this.first_achievement_pick = first_achievement_pick;
        }
    }
}
