using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staller : MonoBehaviour
{
    Coroutine stall;
    public float time;

    public void Awake()
    {
        stall = StartCoroutine(Stalling());
    }

    IEnumerator Stalling()
    {
        yield return new WaitForSeconds(time);
        StopCoroutine(stall);
        GetComponent<StoryEvent>().over = true;
    }
}
