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
        SaveGame();
    }

    public void DisableAllInteractavles()
    {
        eventSystem.GetComponent<MainController>().stop = true;
    }

    public void SaveGame()
    {
        SaveSystem.SaveStoryData(GameObject.FindGameObjectWithTag("GameController").GetComponent<StoryController>());
    }
}
