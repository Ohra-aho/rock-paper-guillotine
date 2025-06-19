using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staller : MonoBehaviour
{
    Coroutine stall;
    public float time;
    MainController MC;

    public void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
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
        MC.SetNewState(MainController.State.stalling);
        GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active = false;
    }

    public void EnableButtons()
    {
        MC.SetNewState(MainController.State.idle);
        GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active = true;
    }
}
