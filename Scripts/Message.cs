using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public List<int> sprite_frames;
    public List<int> dialog_frames;

    GameObject man;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;
    ManAnimator MA;

    private void Awake()
    {
        MA = GameObject.Find("man").GetComponent<ManAnimator>();

        frames = new List<ManAnimator.Frame>();
        for(int i = 0; i < sprite_frames.Count; i++)
        {
            frames.Add(
                new ManAnimator.Frame(
                    MA.man_sheet[sprite_frames[i]], 
                    null, 
                    LanguageController.dialog[dialog_frames[i]]
                )
            );
        }

        DisableButtons();
        GetComponent<StoryEvent>().Procceed();   
    }

    public void DisableButtons()
    {
        GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active = false;
    }

    public void PlayMessage()
    {
        man = GameObject.Find("man");
        man.GetComponent<ManAnimator>().ManMessage(frames);
        activated = true;
    }
}
