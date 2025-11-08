using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMessages : MonoBehaviour
{
    public GameObject message;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;

    MainController MC;

    string[][] intros =
    {
        new string[] { "The next one will be a little tougher.", "Show me what you are made of." },
        new string[] { "You will propably die here.", "And if you do, it has been surprisingly entertaining." },
        new string[] { "Give it your all for the next fight.", "I believe in you." },
        new string[] { "Next foe is one of my persional favourites.", "This ought to be interesting." }
    };

    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        //This is ok for now
        int index = Random.Range(0, intros.Length);
        GameObject new_message = Instantiate(message, transform.parent);
        List<string> temp = new List<string>();

        for (int i = 0; i < intros[index].Length; i++)
        {
            temp.Add(intros[index][i]);
        }
        new_message.GetComponent<Message>().lines = temp;
        new_message.GetComponent<Message>().Inisiate();
        GetComponent<StoryEvent>().over = true;
    }
}
