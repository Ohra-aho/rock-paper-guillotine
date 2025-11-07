using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCheckList : MonoBehaviour
{
    //Tutorial
    public bool first_greeting = false;
    public bool equip_instructions = false;
    public bool battle_instructions = false;

    public bool first_forfeit = false;
    public bool first_victory = false;

    public bool first_boss_met = false;
    public bool first_boss_beaten = false;

    public bool gear_upgrade_1 = false;
    public bool gear_upgrade_2 = false;
    public bool gear_upgrade_3 = false;

    public bool first_achievement = false;

    private void Start()
    {
        LoadStoryCheckList();
    }

    public void SaveStoryCheckList()
    {
        CheckList data = new CheckList
            (
                first_greeting,
                equip_instructions,
                battle_instructions,

                first_forfeit,
                first_victory,

                first_boss_met,
                first_boss_beaten,

                gear_upgrade_1,
                gear_upgrade_2,
                gear_upgrade_3,

                first_achievement
            );
        SaveSystem.SaveStoryChecklist(data);
    }

    public void LoadStoryCheckList()
    {
        CheckList data = SaveSystem.LoadStoryChecklist();
        if(data != null)
        {
            first_greeting = data.first_greeting;
            equip_instructions = data.equip_instructions;
            battle_instructions = data.battle_instructions;

            first_forfeit = data.first_forfeit;
            first_victory = data.first_victory;
            
            first_boss_met = data.first_boss_met;
            first_boss_beaten = data.first_boss_beaten;

            gear_upgrade_1 = data.gear_upgrade_1;
            gear_upgrade_2 = data.gear_upgrade_2;
            gear_upgrade_3 = data.gear_upgrade_3;

            first_achievement = data.first_achievement;
        }
    }

    public class CheckList
    {
        public bool first_greeting;
        public bool equip_instructions;
        public bool battle_instructions;

        public bool first_forfeit;
        public bool first_victory;

        public bool first_boss_met;
        public bool first_boss_beaten;

        public bool gear_upgrade_1;
        public bool gear_upgrade_2;
        public bool gear_upgrade_3;

        public bool first_achievement;

        public CheckList
            (
                bool first_greeting,
                bool equip_instructions,
                bool battle_instructions,

                bool first_forfeit,
                bool first_victory,

                bool first_boss_met,
                bool first_boss_beaten,

                bool gear_upgrade_1,
                bool gear_upgrade_2,
                bool gear_upgrade_3,

                bool first_achievement
            )
        {
            this.first_greeting = first_greeting;
            this.equip_instructions = equip_instructions;
            this.battle_instructions = battle_instructions;
            this.first_forfeit = first_forfeit;
            this.first_victory = first_victory;
            this.first_boss_met = first_boss_met;
            this.first_boss_beaten = first_boss_beaten;
            this.gear_upgrade_1 = gear_upgrade_1;
            this.gear_upgrade_2 = gear_upgrade_2;
            this.gear_upgrade_3 = gear_upgrade_3;
            this.first_achievement = first_achievement;
        }
    }
}
