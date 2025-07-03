using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public int dialog_frames;

    public List<int> sprite_frames;
    //public List<int> dialog_frames;

    public bool tutorial;
    public bool boss_intro;
    public bool boss_victory;
    public bool greeting;


    GameObject man;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;
    ManAnimator MA;

    private void Awake()
    {
        MA = GameObject.Find("man").GetComponent<ManAnimator>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        string[] dialog = ChooseRandomLine();
        //Make a real system for this
        List<int> man_indexes = MakeRandomAnimation(dialog.Length);

        if (sprite_frames.Count <= 0) sprite_frames = man_indexes;

        for (int i = 0; i < sprite_frames.Count; i++)
        {
            string line = dialog[i];
            
            //if (tutorial) line = LanguageController.tutorial[dialog_frames][i];
            //if(boss_intro) line = LanguageController.boss_intros[dialog_frames][i];
            //if(boss_victory) line = LanguageController.boss_victories[dialog_frames][i];
            //if(greeting) line = LanguageController.greetings[dialog_frames][i];

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

    public string[] ChooseRandomLine()
    {
        if(!tutorial)
        {
            //Choose a random dialog from correct set
            if (boss_intro) return LanguageController.boss_intros[Random.Range(0, LanguageController.boss_intros.Length)];
            if (boss_victory) return LanguageController.boss_victories[Random.Range(0, LanguageController.boss_victories.Length)];
            if (greeting) return LanguageController.greetings[Random.Range(0, LanguageController.greetings.Length)];
        } else
        {
            return LanguageController.tutorial[dialog_frames];
        }

        return new string[] { "" };
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
        MC.SetNewState(MainController.State.idle);
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
