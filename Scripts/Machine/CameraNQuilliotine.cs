using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNQuilliotine : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject eventSystem;
    public GameObject event_system;
    public GameObject museum_deathScreen;

    public void RevealDeathScreen()
    {
        GameObject es = GameObject.Find("EventSystem");
        if(!es.GetComponent<StoryCheckList>().executioner_dead)
        {
            if (es.GetComponent<StoryController>().executioner)
            {
                es.GetComponent<StoryCheckList>().executioner_dead = true;
                deathScreen.transform.GetChild(0).gameObject.SetActive(false);
                deathScreen.transform.GetChild(1).gameObject.SetActive(false);
                deathScreen.transform.GetChild(2).gameObject.SetActive(true);
            }
            deathScreen.GetComponent<Test>().PlayAnimation("DeathADone");
        } else
        {
            museum_deathScreen.SetActive(true);
            museum_deathScreen.GetComponent<Test>().PlayAnimation("MDeathADone");
        }
       
        DeathSave();
    }

    public void PlayDeathAnimation()
    {
        GameObject es = GameObject.Find("EventSystem");
        if (es.GetComponent<StoryCheckList>().executioner_dead)
        {
            GetComponent<Test>().PlayAnimation("Lose_2");
        } else
        {
            GetComponent<Test>().PlayAnimation("Lose");
        }
    }

    public void DisableAllInteractavles()
    {
        eventSystem.GetComponent<MainController>().stop = true;
    }

    public void DeathSave()
    {
        SaveSystem.SaveStoryData(eventSystem.GetComponent<StoryController>(), true);
        event_system.GetComponent<RLController>().SaveAchievements();
        event_system.GetComponent<StoryCheckList>().SaveStoryCheckList();
        event_system.GetComponent<SoundSettings>().SaveSoundSettings();

        SaveSystem.DeleteFile(SaveSystem.player_weapon_data);
        SaveSystem.DeleteFile(SaveSystem.player_data);
        SaveSystem.DeleteFile(SaveSystem.bark_data);
    }

    public void DeleteSaveFile()
    {
        SaveSystem.DeleteFile(SaveSystem.story_data);
        SaveSystem.DeleteFile(SaveSystem.bark_data);
        SaveSystem.DeleteFile(SaveSystem.player_weapon_data);
        SaveSystem.DeleteFile(SaveSystem.player_data);
        SaveSystem.DeleteFile(SaveSystem.achievement_data);
        SaveSystem.DeleteFile(SaveSystem.story_checklist_data);
    }

    public void HeadFalls()
    {
        Camera.main.GetComponent<Test>().PlayAnimation("Death");
    }
}
