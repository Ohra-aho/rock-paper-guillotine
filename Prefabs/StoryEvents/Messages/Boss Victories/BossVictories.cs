using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVictories : MonoBehaviour
{
    public GameObject message;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;

    MainController MC;

    string[][] messages =
    {
        new string[] { "Congratulations!", "You did better than I thought." },
        new string[] { "Might need some more fine tuning, that one." },
        new string[] { "..." },
        new string[] { "You did well. I hope you won't dissapoint." },
        new string[] { "Well. It wasn't so bad. Was it?" },
        new string[] { "Might need a buff..." },
        new string[] { "That's how it is done!" },
        new string[] { "Well, that was interesting." }
    };

    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        //This is ok for now
        int index = Random.Range(0, messages.Length);
        GameObject new_message = Instantiate(message, transform.parent);
        List<string> temp = new List<string>();

        for (int i = 0; i < messages[index].Length; i++)
        {
            temp.Add(messages[index][i]);
        }
        new_message.GetComponent<Message>().lines = temp;
        new_message.GetComponent<Message>().Inisiate();
        GetComponent<StoryEvent>().over = true;
    }
}
