using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public List<GameObject> events;
    public Narrative narrative;

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
                    InsertEvent(narrative.boss_introduxtions[boss_index].gameObject, i-1);
                    i++;
                    InsertEvent(narrative.boss_victories[boss_index].gameObject, i);
                    i++;
                    boss_index++;
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
            for(int i = 0; i < events.Count; i++)
            {
                if(events[i].name.Contains("FirstEncounter"))
                {
                    InsertEvent(narrative.before_first_encounter[intro_index].gameObject, i-1);
                    intro_index++;
                    if(intro_index >= narrative.before_first_encounter.Count)
                    {
                        i++;
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
