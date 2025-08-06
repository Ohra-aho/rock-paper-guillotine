using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNQuilliotine : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject eventSystem;

    public void RevealDeathScreen()
    {
        deathScreen.GetComponent<Test>().PlayAnimation("DeathADone");
        DeathSave();
    }

    public void DisableAllInteractavles()
    {
        eventSystem.GetComponent<MainController>().stop = true;
    }

    public void DeathSave()
    {
        SaveSystem.SaveStoryData(eventSystem.GetComponent<StoryController>(), true);
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
    }
}
