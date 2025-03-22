using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staller : MonoBehaviour
{
    Coroutine stall;
    public float time;

    public void Awake()
    {
        DisableButtons();
        stall = StartCoroutine(Stalling());
    }

    IEnumerator Stalling()
    {
        yield return new WaitForSeconds(time);
        StopCoroutine(stall);
        EnableButtons();
        GetComponent<StoryEvent>().over = true;
    }

    public void DisableButtons()
    {
        NonUIButton[] buttons = FindObjectsOfType<NonUIButton>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void EnableButtons()
    {
        NonUIButton[] buttons = FindObjectsOfType<NonUIButton>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
