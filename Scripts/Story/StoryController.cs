using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;
    public GameObject story;

    public int playthroughts = 0;

    //public GameObject story;

    int storyIndex = -1;

    private void Awake()
    {
        StoryData story_data = SaveSystem.LoadStoryData();
        if(story_data != null)
        {
            playthroughts = story_data.playthroughs;
        }

        story = Instantiate(GetComponent<MainController>().playthroughts[0], transform);
        if(playthroughts == 0)
        {
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Tutorial").GetComponent<Narrative>();
        } else
        {
            int game_index = Random.Range(1, 2);
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Game_"+game_index).GetComponent<Narrative>();
        }
        story.GetComponent<Story>().AddBossSpeetches();
        story.GetComponent<Story>().AddIntroSpeeches();
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
}
