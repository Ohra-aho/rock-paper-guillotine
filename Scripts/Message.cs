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


    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MA = GameObject.Find("man").GetComponent<ManAnimator>();
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        string[] dialog = lines.ToArray();
        //Make a real system for this
        List<int> man_indexes = MakeRandomAnimation(dialog.Length);

        if (sprite_frames.Count <= 0) sprite_frames = man_indexes;

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


    //Temporary solution till I figure out hard code solution
    public List<int> MakeRandomAnimation(int amount)
    {
        MA = GameObject.Find("man").GetComponent<ManAnimator>();

        List<int> temp = new List<int>();

        for(int i = 0; i < amount; i++)
        {
            //temp.Add(Random.Range(0, MA.man_sheet.Length));
            temp.Add(0); //Adding just blanks
        }
        return temp;
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
        man.GetComponent<ManAnimator>().ManMessage(frames);
        activated = true;
    }
}
