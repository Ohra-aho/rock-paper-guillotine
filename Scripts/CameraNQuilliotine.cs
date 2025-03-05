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
    }

    public void DisableAllInteractavles()
    {
        eventSystem.GetComponent<MainController>().stop = true;
    }

    public void PlayAudio(int clip)
    {
        transform.GetChild(2).GetChild(clip).GetComponent<AudioPlayer>().PlayClip();
    }
}
