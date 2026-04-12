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

    public bool executioner_dead = false;

    public int end_counter = 0;

    public int greeting_index = 0;

    public bool off_balance_explained = false;
    public bool unbeatable_explained = false;
    public bool useless_explained = false;

    public void SaveStoryCheckList()
    {
        CheckList data = new CheckList
            (
                first_forfeit,
                first_victory,

                first_boss_met,
                first_boss_beaten,

                first_achievement,
                first_achievement_pick,

                executioner_dead,

                greeting_index,

                end_counter,

                off_balance_explained,
                unbeatable_explained,
                useless_explained
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

            greeting_index = data.greeting_index;

            //executioner_dead = data.executioner_dead;
            executioner_dead = true; //Debug

            end_counter = data.end_counter;

            off_balance_explained = data.off_balance_explained;
            unbeatable_explained = data.unbeatable_explained;
            useless_explained = data.useless_explained;
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

        public bool executioner_dead;

        public int greeting_index;

        public int end_counter;

        public bool off_balance_explained;
        public bool unbeatable_explained;
        public bool useless_explained;

        public CheckList
            (
                bool first_forfeit,
                bool first_victory,

                bool first_boss_met,
                bool first_boss_beaten,

                bool first_achievement,
                bool first_achievement_pick,

                bool executioner_dead,

                int greeting_index,

                int end_counter,

                bool off_balance_explained,
                bool unbeatable_explained,
                bool useless_explained
            )
        {
            this.first_forfeit = first_forfeit;
            this.first_victory = first_victory;
            this.first_boss_met = first_boss_met;
            this.first_boss_beaten = first_boss_beaten;
            this.first_achievement = first_achievement;
            this.first_achievement_pick = first_achievement_pick;
            this.greeting_index = greeting_index;
            this.executioner_dead = executioner_dead;
            this.end_counter = end_counter;
            this.off_balance_explained = off_balance_explained;
            this.unbeatable_explained = unbeatable_explained;
            this.useless_explained = useless_explained;
        }
    }
}
