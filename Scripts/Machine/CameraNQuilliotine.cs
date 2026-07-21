using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNQuilliotine : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject eventSystem;
    public GameObject event_system;
    public GameObject museum_deathScreen;

	public Sprite museum_guillotine;

	public void ChangeToMuseum()
	{
		transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = museum_guillotine;
	}

	public void RevealDeathScreen()
    {
        GameObject es = GameObject.Find("EventSystem");
        if(!es.GetComponent<StoryController>().museum_active)
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
        if (es.GetComponent<StoryController>().museum_active)
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
        SaveSystem.SaveStoryData(
			eventSystem.GetComponent<StoryController>(), 
			eventSystem.GetComponent<RLController>(), 
			eventSystem.GetComponent<StoryCheckList>(),
			new PlayThroughData(FindEncounter()),
			true
			);
        event_system.GetComponent<SoundSettings>().SaveSoundSettings();

        SaveSystem.DeleteFile(SaveSystem.player_weapon_data);
        SaveSystem.DeleteFile(SaveSystem.player_data);
    }

	public void NormalSave()
	{
		SaveSystem.SaveStoryData(
			eventSystem.GetComponent<StoryController>(), 
			eventSystem.GetComponent<RLController>(), 
			eventSystem.GetComponent<StoryCheckList>(),
			new PlayThroughData(FindEncounter()),
			false
			);
        event_system.GetComponent<SoundSettings>().SaveSoundSettings();
	}

	private Encounter FindEncounter()
	{
		Encounter temp = null;
		GameObject SEH = GameObject.Find("Story Event Holder");
		if(SEH.transform.childCount > 0)
		{
			if(SEH.transform.GetChild(0).GetComponent<Encounter>())
			{
				if(!SEH.transform.GetChild(0).gameObject.name.Contains("Boss"))
				{
					temp = SEH.transform.GetChild(0).GetComponent<Encounter>();
				}
			}
		}
		return temp;
	}

    public void DeleteSaveFile()
    {
        SaveSystem.DeleteFile(SaveSystem.story_data);
        SaveSystem.DeleteFile(SaveSystem.player_weapon_data);
        SaveSystem.DeleteFile(SaveSystem.player_data);
    }

    public void HeadFalls()
    {
        Camera.main.GetComponent<Test>().PlayAnimation("Death");
    }
}
