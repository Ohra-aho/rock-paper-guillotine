using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public List<GameObject> events;
    public Narrative narrative;

    StoryCheckList SCL;
    StoryController SC;

    private void Awake()
    {
        SCL = transform.parent.GetComponent<StoryCheckList>();
        SC = transform.parent.GetComponent<StoryController>();
    }

    //Adds bossintros before bossbattles and boss victory speeches after boss battles
    public void AddBossSpeetches()
    {
        int boss_index = 0;
        if(narrative.boss_introduxtions != null && narrative.boss_introduxtions.Count > 0)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].name.Contains("Boss"))
                {
                    //tutorial
                    if (boss_index == 0 && !SCL.first_boss_met)
                    {
                        InsertEvent(SC.first_boss_intro, i - 1);
                        i++;
                        InsertEvent(SC.first_boss_victory, i);
                        i++;
                    }
                    else if (boss_index == 0 && !SCL.first_boss_beaten)
                    {
                        InsertEvent(narrative.boss_introduxtions[boss_index].gameObject, i - 1);
                        i++;
                        InsertEvent(SC.first_boss_victory, i);
                        i++;

                        boss_index++;
                    }
                    //Non tutorial
                    else
                    {
                        InsertEvent(narrative.boss_introduxtions[boss_index].gameObject, i - 1);
                        i++;
                        InsertEvent(narrative.boss_victories[boss_index].gameObject, i);
                        i++;

                        boss_index++;
                    }
                }
            }
        }
    }

    public void AddIntroSpeeches()
    {
        int intro_index = 0;
        //Adds all events in the list before the first encounter
        if(narrative.before_first_encounter != null && narrative.before_first_encounter.Count > 0)
        {
            
            for (int i = 0; i < events.Count; i++)
            {
                if(events[i].name.Contains("FirstEncounter"))
                {
                    //Turorials
                    if (!SCL.first_achievement && transform.parent.GetComponent<RLController>().achievements.Count > 0)
                    {
                        if (!SCL.first_achievement_pick && transform.parent.GetComponent<RLController>().picks > 0)
                        {
                            SCL.first_achievement_pick = true;
                            InsertEvent(SC.first_achievement_pick, i - 1);
                        }
                        InsertEvent(SC.first_achievement, i - 1);
                        SCL.first_achievement = true;
                        break;
                    } else if(!SCL.first_achievement_pick && transform.parent.GetComponent<RLController>().picks > 0)
                    {
                        SCL.first_achievement_pick = true;
                        InsertEvent(SC.first_achievement_pick, i - 1);
                        break;
                    } 
                    else
                    {
                        //Non tutorials
                        InsertEvent(narrative.before_first_encounter[intro_index].gameObject, i - 1);
                        intro_index++;

                        if (intro_index >= narrative.before_first_encounter.Count)
                        {
                            break;
                            i++;
                        }
                    }
                    
                }
            }
        }
    }

    //Adds event to set index in events list
    private void InsertEvent(GameObject new_event, int index)
    {
        List<GameObject> temp_start = new List<GameObject>();
        List<GameObject> temp_end = new List<GameObject>();

        //Seperate events to two lists and insert new event between them
        for (int j = 0; j <= index; j++)
        {
            temp_start.Add(events[j]);
        }
        for (int j = index + 1; j < events.Count; j++)
        {
            temp_end.Add(events[j]);
        }
        
        temp_start.Add(new_event);
        temp_start.AddRange(temp_end);
        events.Clear();
        events.AddRange(temp_start);
        
    }

    public void CreateDeathBark()
    {
        Instantiate(narrative.death);
    }

}
