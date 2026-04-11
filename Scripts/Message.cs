using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public List<string> lines;
    public List<int> sprite_frames;

    GameObject man;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;
    ManAnimator MA;
    MainController MC;

    public bool executioner = false;


    private void Update()
    {
        if(MC == null) MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        if(GetComponent<End>())
        {
            GetComponent<End>().Inisiate();
        }
        if(lines.Count > 0)
        {
            Inisiate();
        }  
    }

    public void Inisiate()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        if (!executioner && !MC.GetComponent<StoryController>().executioner)
        {
            if (GameObject.Find("man") != null) HandleMessage();
        } else if(executioner && MC.GetComponent<StoryController>().executioner)
        {
            if (GameObject.Find("man") != null) HandleMessage();
        } else
        {
            GetComponent<StoryEvent>().over = true;
        }
    }

    private void HandleMessage()
    {
        MA = GameObject.Find("man").GetComponent<ManAnimator>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        string[] dialog = lines.ToArray();

        for (int i = 0; i < sprite_frames.Count; i++)
        {
            string line = dialog[i];

            frames.Add(
                new ManAnimator.Frame(
                    MA.man_sheet[sprite_frames[i]],
                    null,
                    line
                )
            );
        }

        DisableButtons();
        GetComponent<StoryEvent>().Procceed();

    }

    private void OnDestroy()
    {
        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        if(MC != null)
        {
            MC.SetNewState(MainController.State.idle);
        }
    }

    public void DisableButtons()
    {
        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        MC.buttons_active = false;
        MC.SetNewState(MainController.State.dialog);
    }

    public void PlayMessage()
    {
        man = GameObject.Find("man");
        if(man != null) man.GetComponent<ManAnimator>().ManMessage(frames);
        activated = true;
    }
}
