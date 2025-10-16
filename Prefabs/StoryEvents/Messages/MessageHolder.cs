using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHolder : MonoBehaviour
{
    public  List<GameObject> messages;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;

    MainController MC;


    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        int index = Random.Range(0, messages.Count);
        Instantiate(messages[index], transform.parent);

        GetComponent<StoryEvent>().over = true;
    }
}
