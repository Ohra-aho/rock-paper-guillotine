using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keppi : MonoBehaviour
{
    public void Missed()
    {
        GameObject.Find("Wanderer(Clone)").GetComponent<Wanderer>().stick_missed = true;
    }
}
