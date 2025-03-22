using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public int id;
    GameObject man;
    [HideInInspector] public bool activated = false;

    private void Awake()
    {
        DisableButtons();
        GetComponent<StoryEvent>().Procceed();   
    }

    public void DisableButtons()
    {
        NonUIButton[] buttons = FindObjectsOfType<NonUIButton>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    /*private void Update()
    {
        if(man != null && activated)
        {
            GetComponent<StoryEvent>().over = true;   
        }
    }*/

    public void PlayMessage()
    {
        man = GameObject.Find("man");
        man.GetComponent<ManAnimator>().ManMessage(id);
        activated = true;
    }
}
