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
        GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active = false;
    }

    public void EnableButtons()
    {
        GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active = true;
    }
}
