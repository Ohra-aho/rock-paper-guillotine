using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;
    public GameObject story;

    //For save system
    /*[HideInInspector]*/ public int playthroughts = 0;
    [HideInInspector] public int storyIndex = -1;
    [HideInInspector] public int narrative_index = -1; 

    private void Awake()
    {
        LoadStory();

        //Set base for the playthrough (at this point there is just one)
        story = Instantiate(GetComponent<MainController>().playthroughts[0], transform);

        //If its the first playthrough, set the tutorial
        if(playthroughts == 0)
        {
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Tutorial").GetComponent<Narrative>();
        } else if(narrative_index == -1)
        {
            int game_index = Random.Range(1, 2);
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Game_" + game_index).GetComponent<Narrative>();
        } else
        {
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Game_" + narrative_index).GetComponent<Narrative>();
        }
        story.GetComponent<Story>().AddBossSpeetches();
        story.GetComponent<Story>().AddIntroSpeeches();
        story.GetComponent<Story>().CreateDeathBark();
        events.AddRange(story.GetComponent<Story>().events);

    }

    public void InvokeNextEvent()
    {
        if(story_event_holder.transform.childCount == 0 && storyIndex < events.Count-1)
        {
            storyIndex++;
            GameObject new_event = Instantiate(events[storyIndex], story_event_holder.transform);
        } 
    }

    private void LoadStory() {
        StoryData story_data = SaveSystem.LoadStoryData();
        if (story_data != null)
        {
            playthroughts = story_data.playthroughs;
            if (story_data.encounter_index == -1)
            {
                narrative_index = -1;
            }
            else
            {
                storyIndex = story_data.encounter_index - 1;
                narrative_index = story_data.narrative_index;
            }
        }
    }

    /*private void CheckForPreviousBarkEvents()
    {
        if(storyIndex != -1)
        {
            for(int i = storyIndex; i > 0; i--)
            {
                if(story.GetComponent<Story>().events[i].GetComponent<BarkCreator>())
                {
                    Instantiate(events[i], story_event_holder.transform);
                } else
                {
                    break;
                }
            }
        }
    }*/
}
